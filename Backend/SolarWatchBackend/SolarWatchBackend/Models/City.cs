namespace SolarWatchBackend.Models;

public class City
{
    public string Name { get; init; }
    public float Lat { get; init; }
    public float Lng { get; init; }
    public string? Country { get; init; }

    public City(string name, float lat, float lng, string? country)
    {
        Name = name;
        Lat = lat;
        Lng = lng;
        Country = country;
    }
}