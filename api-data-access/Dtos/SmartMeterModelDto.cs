namespace api_data_access.Dtos;

public class SmartMeterModelDto
{
   public Guid SmartMeterId { get; set; }
    public DateTime Timestamp { get; set; }
    public double TotalProduction { get; set; }
    public double SolarProduction { get; set; }
    public double WindProduction { get; set; }
    public double OtherProduction { get; set; }
    public double TotalConsumption { get; set; }
    public bool MaintenanceMode { get; set; }
}
