using System.Collections.Generic;

namespace WebApi_G_Map.Models
{
    public class GeoMessageV1 : GeoCommentsV1
    {
        public int Id { get; set; }

        public GeoUser GeoUsers { get; set; }

    }

    public class GeoCommentsV1
    {
        public string message { get; set; }

        public double Lognitude { get; set; }

        public double latitude { get; set; }

        public GeoMessageV1 ToModel()
        {
            return new GeoMessageV1
            {
                message = this.message,
                Lognitude = this.Lognitude,
                latitude = this.latitude
            };

        }

        public GeoCommentsV1 ToComments()
        {
            return this;
        }
    }
}
