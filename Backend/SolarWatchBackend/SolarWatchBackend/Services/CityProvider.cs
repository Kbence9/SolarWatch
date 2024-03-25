using SolarWatchBackend.Models;
using SolarWatchBackend.Repositories;

namespace SolarWatchBackend.Services;

public class CityProvider : ICityProvider
{
    private readonly ILogger<CityProvider> _logger;
    private readonly IJsonProcessor _jsonProcessor;
    private readonly ICityRepository _cityRepository;

    public CityProvider(ILogger<CityProvider> logger, IJsonProcessor jsonProcessor, ICityRepository cityRepository)
    {
        _logger = logger;
        _jsonProcessor = jsonProcessor;
        _cityRepository = cityRepository;
    }

    public async Task<City> GetCity(string cityName)
    {
        var city = _cityRepository.GetByName(cityName);

        if (city != null)
        {
            return city;
        }
        
        var apiKey = Environment.GetEnvironmentVariable("APIKEY");
        var url = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&appid={apiKey}";

        using var client = new HttpClient();
        
        _logger.LogInformation("Calling OpenWeather API with url: {url}", url);
        var response = await client.GetAsync(url);
        city = _jsonProcessor.ProcessCity(await response.Content.ReadAsStringAsync(), cityName);
        _cityRepository.Add(city);
        return city;
        
    }
}