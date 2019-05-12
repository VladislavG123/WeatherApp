using Newtonsoft.Json;

namespace WeatherApp.Models
{
    [JsonObject("Envelope")]
    public class Position
    {
        public string LowerCorner { get; set; }
        public string UpperCorner { get; set; }
    }
    public class BoundedBy
    {
        [JsonProperty("Envelope")]
        public Position Position { get; set; }
    }

    public class GeocoderResponseMetaData
    {
        public string Request { get; set; }
        public BoundedBy BoundedBy { get; set; }
    }

    public class MetaDataProperty
    {
        public GeocoderResponseMetaData GeocoderResponseMetaData { get; set; }
    }


    public class GeoObjectCollection
    {
        public MetaDataProperty MetaDataProperty { get; set; }
    }

    public class Response
    {
        public GeoObjectCollection GeoObjectCollection { get; set; }
    }

    [JsonObject("RootObject")]
    public class GeoCodeService
    {
        public Response Response { get; set; }
    }
}
