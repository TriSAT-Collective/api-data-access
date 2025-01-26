namespace api_data_access;
/// <summary>
/// Represents the application settings.
/// </summary>
public class AppSettings
{
    /// <summary>
    /// Gets or sets the MongoDB settings.
    /// </summary>
    public MongoDBSettings MongoDB { get; set; }
    /// <summary>
    /// Gets or sets the API settings.
    /// </summary>
    public ApiSettings Api { get; set; }
    /// <summary>
    /// Represents the MongoDB settings.
    /// </summary>
    public class MongoDBSettings
    {
        /// <summary>
        /// Gets or sets the MongoDB connection string.
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Gets or sets the SmartMeter MongoDB settings.
        /// </summary>
        public SmartMeterMongoDBSettings SmartMeter { get; set; }
        /// <summary>
        /// Gets or sets the Weather MongoDB settings.
        /// </summary>
        public WeatherMongoDBSettings Weather { get; set; }
        /// <summary>
        /// Represents the Weather MongoDB settings.
        /// </summary>
        public class SmartMeterMongoDBSettings
        {
            /// <summary>
            /// Gets or sets the Weather database name.
            /// </summary>
            public string DatabaseName { get; set; }
        }
        
        public class WeatherMongoDBSettings
        {
            public string DatabaseName { get; set; }
        }
    }
    /// <summary>
    /// Represents the API settings.
    /// </summary>
    public class ApiSettings
    {
        /// <summary>
        /// Gets or sets the base path for the API.
        /// </summary>
        public string PathBase { get; set; } = "/api";
        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        public string ApiKey { get; set; }
    }
}
