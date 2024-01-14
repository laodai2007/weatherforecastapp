using Microsoft.AspNetCore.Mvc;
using WeatherApp.Application;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly WeatherInfoService _weatherInfoService;
    private readonly IConfiguration _configuration;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherInfoService weatherInfoService, IConfiguration configuration)
    {
        _logger = logger;
        _weatherInfoService = weatherInfoService;
        _configuration = configuration;
    }

    [HttpGet("{code}", Name = "GetWeatherForecast")]
    public async Task<IActionResult> GetWeatherByCode(string code)
    {
        string url = _configuration.GetSection("AppSettings:WeatherStackAPIUrl").Value + code;
        var result = await _weatherInfoService.GetWeatherInfos(url);

        if (result != null)
        {
            return Ok(result);
        }
        return StatusCode(500, "Internal server error");
    }
}
