using SolarWatchBackend.Models;

namespace SolarWatchBackend.Services;

public interface IJsonProcessor
{
    City ProcessCity(string data, string cityName);

    SunSetRise ProcessSunSetRise(string data, string city, DateTime date);
}