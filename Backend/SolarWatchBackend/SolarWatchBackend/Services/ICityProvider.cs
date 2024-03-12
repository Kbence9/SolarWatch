using SolarWatchBackend.Models;

namespace SolarWatchBackend.Services;

public interface ICityProvider
{
    Task<City> GetCity(string city);
}