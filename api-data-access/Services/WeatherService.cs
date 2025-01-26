using api_data_access.Dtos;
using api_data_access.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using trisatenergy_api_geosphere;

namespace api_data_access.Services;

public class WeatherService
{
    private readonly IMongoCollection<WeatherTimeSeriesModel> _weatherHistoricalCollection;
    private readonly IMongoCollection<WeatherTimeSeriesModel> _weatherForecastCollection;

    private readonly ILogger<WeatherService> _logger;

    public WeatherService(IOptions<AppSettings> appSettings, ILogger<WeatherService> logger)
    {
        _logger = logger;
        var client = new MongoClient(appSettings.Value.MongoDB.ConnectionString);
        var database = client.GetDatabase(appSettings.Value.MongoDB.Weather.DatabaseName);
        _weatherHistoricalCollection = database.GetCollection<WeatherTimeSeriesModel>("timeseries_historical");
        _weatherForecastCollection = database.GetCollection<WeatherTimeSeriesModel>("timeseries_forecast");
    }

    public enum WeatherType
    {
        Historical,
        Forecast
    }

    public async Task<IEnumerable<WeatherTimeSeriesModelDto>> GetWeatherData(WeatherType type, DateTime? from,
        DateTime? to)
    {
        var filterBuilder = Builders<WeatherTimeSeriesModel>.Filter;
        var filter = filterBuilder.Empty;

        if (from.HasValue)
        {
            filter &= filterBuilder.Gte("Timestamp", from.Value);
        }

        if (to.HasValue)
        {
            filter &= filterBuilder.Lte("Timestamp", to.Value);
        }

        var projection = Builders<WeatherTimeSeriesModel>.Projection.Expression(x => new WeatherTimeSeriesModelDto()
        {
            Timestamp = x.Timestamp,
            T2M = x.T2M,
            UU = x.UU,
            VV = x.VV,
            Geometry = x.Geometry
        });

        var collection = type.Equals(WeatherType.Historical)
            ? _weatherHistoricalCollection
            : _weatherForecastCollection;

        return await collection.Find(filter).Project(projection).ToListAsync();
    }
}