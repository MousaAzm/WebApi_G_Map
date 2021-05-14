using System.Text.Json.Serialization;

namespace WebApi_G_Map.Models
{
    public class GeoMessageV1
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public GeoUser GeoUsers { get; set; }

        public string message { get; set; }

        public double longitude { get; set; }

        public double latitude { get; set; }
    }

}
