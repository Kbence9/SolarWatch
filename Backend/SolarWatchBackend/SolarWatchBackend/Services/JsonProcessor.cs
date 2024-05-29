using System.Text.Json;
using SolarWatchBackend.Models;

namespace SolarWatchBackend.Services;

public class JsonProcessor : IJsonProcessor
{
    public City ProcessCity(string data, string cityName)
    {
        var json = JsonDocument.Parse(data);

        var city = new City(
            cityName,
            (float)json.RootElement[0].GetProperty("lat").GetDecimal(),
            (float)json.RootElement[0].GetProperty("lon").GetDecimal(),
            json.RootElement[0].GetProperty("country").GetString()
            );

        return city;
    }
    
    public SunSetRise ProcessSunSetRise(string data, string city, DateTime date)
    {
        var json = JsonDocument.Parse(data);
        var result = json.RootElement.GetProperty("results");

        var sunSetRise = new SunSetRise(
            city,
            date,
            result.GetProperty("sunrise").GetDateTime(),
            result.GetProperty("sunset").GetDateTime()
            );

        return sunSetRise;
    }
    
    private static DateTime GetDateTimeFromUnixTimeStamp(long timeStamp)
    {
        var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timeStamp);
        var dateTime = dateTimeOffset.UtcDateTime;

        return dateTime;
    }
}