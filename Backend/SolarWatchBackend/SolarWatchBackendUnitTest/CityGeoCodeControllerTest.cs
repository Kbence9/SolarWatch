using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SolarWatchBackend.Controllers;
using SolarWatchBackend.Services;

namespace SolarWatchBackendUnitTest;

[TestFixture]
public class CityGeoCodeControllerTest
{
    private Mock<ILogger<CityGeoCodeController>> _loggerMock;
    private Mock<ICityProvider> _cityProviderMock;
    private Mock<IJsonProcessor> _jsonProcessorMock;
    private CityGeoCodeController _controller;

    [SetUp]
    public void SetUp()
    {
        _loggerMock = new Mock<ILogger<CityGeoCodeController>>();
        _jsonProcessorMock = new Mock<IJsonProcessor>();
        _cityProviderMock = new Mock<ICityProvider>();
        _controller = new CityGeoCodeController(_loggerMock.Object, _cityProviderMock.Object);
    }

    [Test]
    public void GetCityGeoCodeWithLowerCaseSuccessfulTest()
    {
        const string city = "budapest";

        var cityProvidedResult = _controller.GetCityGeoCode(city);

        Assert.That(cityProvidedResult.Result, Is.InstanceOf(typeof(OkObjectResult)));

    }
    

}