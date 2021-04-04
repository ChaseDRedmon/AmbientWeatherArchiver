using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Extensions.Options;
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
        
        public Task OpenConnection();
    }

    public sealed class AmbientWeatherRealtime : IAmbientWeatherRealtime, IDisposable
    {
        private SocketIO Client { get; set; }
        private static Uri BaseAddress { get; } = new Uri("https://dash2.ambientweather.net");
        private Timer Timer { get; set; }
        
        /// <inheritdoc cref="OnDataReceived"/>
        public event IAmbientWeatherRealtime.OnDataReceivedHandler OnDataReceived;
        
        /// <inheritdoc cref="OnSubscribe"/>
        public event IAmbientWeatherRealtime.OnSubcribeHandler OnSubscribe;

        private WeatheredConfig _options { get; }

        private readonly ILogger _log;

        public AmbientWeatherRealtime(IOptions<WeatheredConfig> options, ILogger logger): this(options)
        {
            _log = logger.ForContext<AmbientWeatherRealtime>();
        }
        
        public AmbientWeatherRealtime(IOptions<WeatheredConfig> options)
        {
            _options = options.Value;
        }

        public async Task OpenConnection()
        {
            var apiKeys = _options.ApiKey;
            var applicationKey = _options.ApplicationKey;

            Client = new SocketIO(BaseAddress, new SocketIOOptions
            {
                EIO = 4,
                Query = new Dictionary<string, string>
                {
                    {"api", "1"},
                    {"applicationKey", applicationKey}
                }
            });
            
            var keys = new Root
            {
                apiKeys = apiKeys
            };

            Client.On("subscribed", OnInternalSubscribeEvent);
            Client.On("data", OnInternalDataEvent);

            Client.OnConnected += OnInternalConnectEvent;
            Client.OnDisconnected += OnInternalDisconnectEvent;
            
            _log.Information($"Opening websocket connection: {BaseAddress}");
            await Client.ConnectAsync();
            
            _log.Information($"Sending Subcribe Command: {BaseAddress}");
            await Client.EmitAsync("subscribe", keys);

            Timer = new Timer { Interval = 15000 };
            Timer.Elapsed += KeepConnectionAlive;
            Timer.Start();

            await Task.Delay(-1);
        }

        private void OnInternalDisconnectEvent(object sender, string e)
        {
            _log.Information("API Disconnected");
        }

        private void OnInternalConnectEvent(object sender, EventArgs e)
        {
            _log.Information("Connected to API");
        }

        private async void OnInternalSubscribeEvent(SocketIOResponse obj)
        {
            _log.Information("Subscribed to service");
            OnSubscribe?.Invoke(this, new OnSubscribeEventArgs(obj.GetValue()));
        }

        private async void OnInternalDataEvent(SocketIOResponse obj)
        {
            _log.Information("Received data event");
            OnDataReceived?.Invoke(this, new OnDataReceivedEventArgs(obj.GetValue()));
        }

        private async void KeepConnectionAlive(object source, ElapsedEventArgs e)
        {
            // This "ping" event emulates a keep-alive message to prevent the API from disconnecting
            _log.Information("Sending ping keep-alive");
            await Client.EmitAsync("ping");
        }

        private void ReleaseUnmanagedResources()
        {
            Client.Off("subscribed");
            Client.Off("data");

            Client.OnConnected -= OnInternalConnectEvent;
            Client.OnDisconnected -= OnInternalDisconnectEvent;
            
            // Tell the API we are disconnecting
            Client.EmitAsync("disconnect").Wait();
            Client.DisconnectAsync().Wait();
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                Timer.Elapsed -= KeepConnectionAlive;
            
                Timer.Stop();
                Timer.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~AmbientWeatherRealtime()
        {
            Dispose(false);
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