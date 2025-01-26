

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace trisatenergy_api_geosphere
{
    public class WeatherTimeSeriesModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        public double T2M { get; set; }
        public double UU { get; set; }
        
        public double VV { get; set; }


        [BsonElement("geometry")]
        public GeoJsonGeometry Geometry { get; set; }
    }

    public class Root
    {
        public List<string> Timestamps { get; set; }
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        public GeoJsonGeometry Geometry { get; set; }
        public Properties Properties { get; set; }
        public string Type { get; set; }
    }

    public class Properties
    {
        public Parameters Parameters { get; set; }
    }

    public class Parameters
    {
        public Parameter T2M { get; set; }
        public Parameter UU { get; set; }
        public Parameter UGUST { get; set; }
        public Parameter VV { get; set; }
        public Parameter VGUST { get; set; }
    }

    public class Parameter
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public List<double> Data { get; set; }
    }

    public class GeoJsonGeometry
    {
        [BsonElement("type")]
        public string Type { get; set; } = "Point";

        [BsonElement("coordinates")]
        public List<double> Coordinates { get; set; }
    }
}