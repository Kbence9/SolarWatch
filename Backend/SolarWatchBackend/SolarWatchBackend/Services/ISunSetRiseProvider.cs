using SolarWatchBackend.Models;

namespace SolarWatch.Services;

public interface ISunSetRiseProvider
{
    Task<SunSetRise> GetSunSetAndRise(float lat, float lng, DateTime date, string city);
}