using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_data_access.Models;

public class SmartMeterModel
{
    
    [BsonId] public ObjectId Id { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime Timestamp { get; set; }
    
    [BsonRepresentation(BsonType.String)] public Guid SmartMeterId { get; set; }

    public double TotalProduction { get; set; }

    public double SolarProduction { get; set; }
    public double WindProduction { get; set; }
    public double OtherProduction { get; set; }

    public double TotalConsumption { get; set; }
    public bool MaintenanceMode { get; set; }
}
