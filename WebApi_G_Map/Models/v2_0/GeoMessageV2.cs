using System.Collections.Generic;

namespace WebApi_G_Map.Models
{
    public class GeoMessageV2 : GeoCommentsV2
    {
        public int Id { get; set; }

        public GeoUser GeoUsers { get; set; }
    }

    public class GeoCommentsV2
    {
        public string body { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public double Lognitude { get; set; }

        public double latitude { get; set; }

        public GeoMessageV2 ToModel()
        {
            return new GeoMessageV2
            {
                body = this.body,
                Title = this.Title,
                Author = this.Author,
                Lognitude = this.Lognitude,
                latitude = this.latitude
            };

        }

        public GeoCommentsV2 ToComments()
        {
            return this;
        }
    }
}
