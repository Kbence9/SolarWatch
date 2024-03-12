using SolarWatchBackend.Models;

namespace SolarWatchBackend.Services;

public interface ISunSetRiseProvider
{
    Task<SunSetRise> GetSunSetAndRise(float lat, float lng, DateTime date, string city);
}