namespace SolarWatchBackend.Models;

public class City
{
    public string Name { get; init; }
    public float Lat { get; init; }
    public float Lng { get; init; }
    public string Country { get; init; }
    public string State { get; init; }

    public City(string name, float lat, float lng, string country, string state)
    {
        Name = name;
        Lat = lat;
        Lng = lng;
        Country = country;
        State = state;
    }
}