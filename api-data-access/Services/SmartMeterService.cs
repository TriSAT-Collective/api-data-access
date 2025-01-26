using api_data_access.Dtos;
using api_data_access.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace api_data_access.Services;

public class SmartMeterService
{
    private readonly IMongoCollection<SmartMeterModel> _smartMeterCollection;

    private readonly ILogger<SmartMeterService> _logger;

    public SmartMeterService(IOptions<AppSettings> appSettings, ILogger<SmartMeterService> logger)
    {
        _logger = logger;
        var client = new MongoClient(appSettings.Value.MongoDB.ConnectionString);
        var database = client.GetDatabase(appSettings.Value.MongoDB.SmartMeter.DatabaseName);
        _smartMeterCollection = database.GetCollection<SmartMeterModel>("simulated_data");
    }

    public async Task<IEnumerable<Guid>> GetAllSmartMeterIds()
    {
        var ids = await _smartMeterCollection.DistinctAsync<Guid>("SmartMeterId", new BsonDocument());
        return ids.ToList();
    }

    public async Task<IEnumerable<SmartMeterModelDto>> GetSmartMeterData(Guid id, DateTime? from, DateTime? to)
    {
        var filterBuilder = Builders<SmartMeterModel>.Filter;
        var filter = filterBuilder.Eq("SmartMeterId", id);
        if (from.HasValue)
        {
            filter &= filterBuilder.Gte("Timestamp", from.Value);
        }

        if (to.HasValue)
        {
            filter &= filterBuilder.Lte("Timestamp", to.Value);
        }

        var projection = Builders<SmartMeterModel>.Projection.Expression(x => new SmartMeterModelDto
        {
            SmartMeterId = x.SmartMeterId,
            Timestamp = x.Timestamp,
            TotalProduction = x.TotalProduction,
            SolarProduction = x.SolarProduction,
            WindProduction = x.WindProduction,
            OtherProduction = x.OtherProduction,
            TotalConsumption = x.TotalConsumption,
            MaintenanceMode = x.MaintenanceMode
        });

        var result = await _smartMeterCollection.Find(filter).Project(projection).ToListAsync();
        return result;
    }
}