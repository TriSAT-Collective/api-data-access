using api_data_access.Dtos;
using api_data_access.Models;
using api_data_access.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace api_data_access.Controllers;

[ApiController]
[Route("[controller]")]
public class SmartMeterController : Controller
{
    
    private readonly ILogger<SmartMeterController> _logger;
    private readonly SmartMeterService _smartMeterService;
    
    public SmartMeterController(ILogger<SmartMeterController> logger, SmartMeterService smartMeterService)
    {
        _logger = logger;
        _smartMeterService = smartMeterService;
    }
    
    [HttpGet ("ids")]
    public async Task<IEnumerable<Guid>> GetAllSmartMeterIds()
    {
        return await _smartMeterService.GetAllSmartMeterIds();
    }
    
    [HttpGet("data/{id}")]
    public async Task<IEnumerable<SmartMeterModelDto>> GetSmartMeterData(
        Guid id,
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? to)
    {
        return await _smartMeterService.GetSmartMeterData(id, from, to);
    }
}