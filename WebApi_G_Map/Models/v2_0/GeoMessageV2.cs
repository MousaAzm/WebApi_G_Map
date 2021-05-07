using System.Collections.Generic;
using WebApi_G_Map.Models;

namespace WebApi_G_Map.Models
{
    public class GeoMessageV2 : GeoCommentsV2
    {

        public int Id { get; set; }
        
        public GeoUser GeoUsers { get; set; }


        
    }


    public class GeoCommentsV2
    {
       
        public double Lognitude { get; set; }

        public double latitude { get; set; }

        public Message Message { get; set; }


        public GeoMessageV2 ToModel()
        {

            return new GeoMessageV2
            {
               
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
