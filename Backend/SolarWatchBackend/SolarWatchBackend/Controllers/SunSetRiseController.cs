using Microsoft.AspNetCore.Mvc;
using SolarWatchBackend.Models;
using SolarWatchBackend.Services;

namespace SolarWatchBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class SunSetRiseController : ControllerBase
{
    private readonly ILogger<SunSetRiseController> _logger;
    private readonly ISunSetRiseProvider _sunSetRiseProvider;
    private readonly ICityProvider _cityProvider;

    public SunSetRiseController(ILogger<SunSetRiseController> logger, ISunSetRiseProvider sunSetRiseProvider, ICityProvider cityProvider)
    {
        _logger = logger;
        _sunSetRiseProvider = sunSetRiseProvider;
        _cityProvider = cityProvider;
    }

    [HttpGet("GetSunSetRise")]
    public ActionResult<SunSetRise> GetSunSetRise(string city, DateTime date)
    {
        try
        {
            var cityGeoCode = _cityProvider.GetCity(city);
            var sunSetRise = _sunSetRiseProvider.GetSunSetAndRise(cityGeoCode.Result.Lat, cityGeoCode.Result.Lng, date, city);
            return Ok(sunSetRise.Result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting sun set/rise data");
            return NotFound("Error getting sun set/rise data");
        }
    }
}