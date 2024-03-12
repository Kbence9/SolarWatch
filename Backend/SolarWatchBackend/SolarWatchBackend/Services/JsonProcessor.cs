using System.Text.Json;
using SolarWatchBackend.Models;

namespace WeatherApi.Services;

public class JsonProcessor : IJsonProcessor
{
    
    public SunSetRise ProcessSunSetRise(string data, string city, DateTime date)
    {
        JsonDocument json = JsonDocument.Parse(data);
        JsonElement result = json.RootElement.GetProperty("results");

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
        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timeStamp);
        DateTime dateTime = dateTimeOffset.UtcDateTime;

        return dateTime;
    }
}