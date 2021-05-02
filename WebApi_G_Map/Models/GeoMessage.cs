using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_G_Map.Models
{
    public class GeoMessage : GeoComments
    {
        public int Id { get; set; }
    }

    public class GeoComments
    {
        public string messagae { get; set; }

        public double Lognitude { get; set; }

        public double latitude { get; set; }

        public GeoMessage ToModel()
        {
            return new GeoMessage
            {
                messagae = this.messagae,
                Lognitude = this.Lognitude,
                latitude = this.latitude
            };  

        }

        public GeoComments ToComments()
        {
            return this;
        }
    }
}
