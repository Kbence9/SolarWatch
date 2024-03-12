using System.Net;
using SolarWatchBackend.Services;
using SolarWatchBackend.Models;
using WeatherApi.Services;

namespace SolarWatchBackend.Services;

public class SunSetRiseProvider : ISunSetRiseProvider
{
    private readonly ILogger<SunSetRiseProvider> _logger;
    private readonly JsonProcessor _jsonProcessor = new();

    public SunSetRiseProvider(ILogger<SunSetRiseProvider> logger)
    {
        _logger = logger;
    }

    public async Task<SunSetRise> GetSunSetAndRise(float lat, float lng, DateTime date, string city)
    {
        var url = $"https://api.sunrise-sunset.org/json?lat={lat}.7201600&lng={lng}.4203400&date={date.Year}-{date.Month}-{date.Day}&formatted=0";

        using var client = new HttpClient();
        
        _logger.LogInformation("Calling sunset-sunrise with url: {url}", url);

        var response = await client.GetAsync(url);

        return _jsonProcessor.ProcessSunSetRise(await response.Content.ReadAsStringAsync(), city, date);
    }
}