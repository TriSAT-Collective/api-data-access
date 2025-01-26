namespace api_data_access;

public class AppSettings
{
    public MongoDBSettings MongoDB { get; set; }
    public ApiSettings Api { get; set; }

    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public SmartMeterMongoDBSettings SmartMeter { get; set; }
        public WeatherMongoDBSettings Weather { get; set; }

        public class SmartMeterMongoDBSettings
        {
            public string DatabaseName { get; set; }
        }
        
        public class WeatherMongoDBSettings
        {
            public string DatabaseName { get; set; }
        }
    }
    
    public class ApiSettings
    {
        public string PathBase { get; set; } = "/api";
    }
}
