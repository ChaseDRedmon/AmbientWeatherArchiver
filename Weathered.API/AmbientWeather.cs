namespace Weathered.API
{
    public class AmbientWeather
    {
        private string? _apiKey;
        private string? _applicationKey;
        private string? DeviceMacAddress { get; set; }
        
        private AmbientWeather(string? apiKey, string? applicationKey, string? deviceMacAddress = null)
        {
            _apiKey = apiKey;
            _applicationKey = applicationKey;
            DeviceMacAddress = deviceMacAddress;
        }
    }
}