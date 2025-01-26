using trisatenergy_api_geosphere;

namespace api_data_access.Dtos;

public class WeatherTimeSeriesModelDto
{
    public DateTime Timestamp { get; set; }
    public double T2M { get; set; }
    public double UU { get; set; }
    public double VV { get; set; }
    public GeoJsonGeometry Geometry { get; set; }
}