using api_data_access.Dtos;
using api_data_access.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_data_access.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class WeatherController : Controller
{
    
    private readonly ILogger<WeatherController> _logger;
    private readonly WeatherService _weatherService;
    
    public WeatherController(ILogger<WeatherController> logger, WeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }
    
    
    [HttpGet("historical")]
    public async Task<ActionResult<IEnumerable<WeatherTimeSeriesModelDto>>> GetHistoricalWeatherData(
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? to)
    {
        try {
            var result = await _weatherService.GetWeatherData(WeatherService.WeatherType.Historical, from, to);
            return Ok(result);
        } catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }
    
     [HttpGet("forecast")]
        public async Task<ActionResult<IEnumerable<WeatherTimeSeriesModelDto>>> GetForecastWeatherData(
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to)
        {
            try {
                var result = await _weatherService.GetWeatherData(WeatherService.WeatherType.Forecast, from, to);
                return Ok(result);
            } catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
}