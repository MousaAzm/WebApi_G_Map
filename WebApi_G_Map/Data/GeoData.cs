using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_G_Map.Models;

namespace WebApi_G_Map.Data
{
    public static class GeoData
    {

        public static void SeedData(GeoMessageContext context)
        {
            Seeding(context);
           
        }

        private static void Seeding(GeoMessageContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var mess = new GeoMessage[]
            {
                new GeoMessage
                {
                    messagae = "hej",
                    Lognitude = 54.457,
                    latitude = 26.44
                }
            };

            context.AddRange(mess);
            context.SaveChanges();

        }
    }
}
