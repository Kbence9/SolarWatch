using SolarWatchBackend.Models;

namespace WeatherApi.Services;

public interface IJsonProcessor
{
    SunSetRise ProcessSunSetRise(string data, string city, DateTime date);
}