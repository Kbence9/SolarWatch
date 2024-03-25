using SolarWatchBackend.Models;

namespace SolarWatchBackend.Services;

public class CityProvider : ICityProvider
{
    private readonly ILogger<CityProvider> _logger;
    private readonly IJsonProcessor _jsonProcessor;

    public CityProvider(ILogger<CityProvider> logger, IJsonProcessor jsonProcessor)
    {
        _logger = logger;
        _jsonProcessor = jsonProcessor;
    }

    public async Task<City> GetCity(string city)
    {
        var apiKey = Environment.GetEnvironmentVariable("APIKEY");
        var url = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&appid={apiKey}";

        using var client = new HttpClient();
        
        _logger.LogInformation("Calling OpenWeather API with url: {url}", url);
        var response = await client.GetAsync(url);
        return _jsonProcessor.ProcessCity(await response.Content.ReadAsStringAsync(), city);
        
    }
}