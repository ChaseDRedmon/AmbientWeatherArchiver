using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using SocketIOClient;
using Weathered.API.Models;

namespace Weathered.API.Realtime
{
    public interface IAmbientWeatherRealtime
    {
        /// <summary>
        /// Handler for our OnDataReceived event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="token">Hands a <see cref="JToken"/>> from the websocket</param>
        public delegate void OnDataReceivedHandler(object sender, OnDataReceivedEventArgs token);
        
        /// <summary>
        /// The OnDataReceived Event fires when it receives an update from the Ambient Weather API
        /// </summary>
        public event OnDataReceivedHandler OnDataReceived;
        
        /// <summary>
        /// Handler for out OnSubcribe event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="token">Hands a <see cref="JToken"/> from the websocket</param>
        public delegate void OnSubcribeHandler(object sender, OnSubscribeEventArgs token);
        
        /// <summary>
        /// The OnSubcribe event fires when a successful subscription is negotiated with the Ambient Weather Websocket server
        /// </summary>
        public event OnSubcribeHandler OnSubscribe;
        
        public Timer Timer { get; set; }
        public Task OpenConnection();
        public Task StartTimer();
        public Task StopTimer();
    }

    public sealed class AmbientWeatherRealtime : IAmbientWeatherRealtime, IDisposable
    {
        private SocketIO Client { get; set; }
        private const string BaseAddress = "https://rt.ambientweather.net";
        public Timer Timer { get; set; }

        /// <inheritdoc cref="OnDataReceivedHandler"/>
        public delegate void OnDataReceivedHandler(object sender, OnDataReceivedEventArgs args);
        
        /// <inheritdoc cref="OnDataReceived"/>
        public event IAmbientWeatherRealtime.OnDataReceivedHandler OnDataReceived;

        /// <inheritdoc cref="OnSubcribeHandler"/>
        public delegate void OnSubcribeHandler(object sender, OnSubscribeEventArgs token);
        
        /// <inheritdoc cref="OnSubscribe"/>
        public event IAmbientWeatherRealtime.OnSubcribeHandler OnSubscribe;

        private IOptions<WeatheredConfig> _options { get; }

        public AmbientWeatherRealtime(IOptions<WeatheredConfig> options)
        {
            _options = options;
        }

        public async Task OpenConnection()
        {
            var ApiKeys = _options.Value.ApiKey;
            var ApplicationKey = _options.Value.ApplicationKey;

            Client = new SocketIO(BaseAddress, new SocketIOOptions
            {
                EIO = 4,
                Query = new Dictionary<string, string>
                {
                    {"api", "1"},
                    {"applicationKey", ApplicationKey}
                }
            });
            
            var keys = new Root
            {
                apiKeys = ApiKeys
            };

            Client.On("subscribed", OnInternalSubscribeEvent);
            Client.On("data", OnInternalDataEvent);

            Client.OnConnected += OnInternalConnectEvent;
            Client.OnDisconnected += OnInternalDisconnectEvent;
            
            Log.Information($"Opening websocket connection: {BaseAddress}");
            await Client.ConnectAsync();
            
            Log.Information($"Sending connect command: {BaseAddress}");
            await Client.EmitAsync("connect");
            
            Log.Information($"Sending Subcribe Command: {BaseAddress}");
            await Client.EmitAsync("subscribe", keys);

            Timer.Elapsed += KeepConnectionAlive;
            
            // If the timer is not enabled, set the enabled flag to true and start the timer
            if (!Timer.Enabled)
            {
                Timer.Enabled = true;
                Timer.Start();
            }

            await Task.Delay(-1);
        }

        public Task StartTimer()
        {
            Timer.Start();
            return Task.CompletedTask;
        }

        public Task StopTimer()
        {
            Timer.Stop();
            return Task.CompletedTask;
        }

        private void OnInternalDisconnectEvent(object sender, string e)
        {
            Log.Information("Disconnected");
        }

        private void OnInternalConnectEvent(object sender, EventArgs e)
        {
            Log.Information("Connected");
        }

        private async void OnInternalSubscribeEvent(SocketIOResponse obj)
        {
            Log.Information("Subscribed to service");
            OnSubscribe?.Invoke(this, new OnSubscribeEventArgs(obj.GetValue()));
        }

        private async void OnInternalDataEvent(SocketIOResponse obj)
        {
            Log.Information("Received data event");
            OnDataReceived?.Invoke(this, new OnDataReceivedEventArgs(obj.GetValue()));
        }

        private async void KeepConnectionAlive(Object source, ElapsedEventArgs e)
        {
            // Prevent the connection from being closed on us
            // The "ping" event doesn't do anything. I just put it there just because
            // This timer emulates keep-alive 
            Log.Information("Ping");
            await Client.EmitAsync("ping");
        }

        public void Dispose()
        {
            Timer.Elapsed -= KeepConnectionAlive;
            
            Timer.Stop();
            Timer.Dispose();
            
            Client.Off("subscribed");
            Client.Off("data");

            Client.OnConnected -= OnInternalConnectEvent;
            Client.OnDisconnected -= OnInternalDisconnectEvent;
            
            // Tell the API we are disconnecting
            Client.EmitAsync("disconnect").Wait();
            Client.DisconnectAsync().Wait();
        }
    }

    public class OnDataReceivedEventArgs
    {
        public OnDataReceivedEventArgs(JToken token)
        {
            Token = token;
        }
        
        public JToken Token { get; }
    }
    
    public class OnSubscribeEventArgs
    {
        public OnSubscribeEventArgs(JToken token)
        {
            Token = token;
        }
        
        public JToken Token { get; }
    }

    public class Root
    {
        public List<string> apiKeys { get; set; }
    }
}