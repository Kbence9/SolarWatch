using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarWatchBackend.Models;
using SolarWatchBackend.Services;

namespace SolarWatchBackend.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CityGeoCodeController : ControllerBase
{
    private readonly ILogger<CityGeoCodeController> _logger;
    private readonly ICityProvider _cityProvider;

    public CityGeoCodeController(ILogger<CityGeoCodeController> logger, ICityProvider cityProvider)
    {
        _logger = logger;
        _cityProvider = cityProvider;
    }

    [HttpGet, Authorize]
    public ActionResult<CityGeoCode> GetCityGeoCode(string city)
    {
        try
        {
            var cityGeoCode = _cityProvider.GetCity(city);
            return Ok(cityGeoCode.Result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting geocode data");
            return Problem("Error getting geocode data");
        }
    }
    
}