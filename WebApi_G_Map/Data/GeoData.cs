using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_G_Map.Models;

namespace WebApi_G_Map.Data
{
    public static class GeoData
    {

        public static void SeedData(GeoMessageContext context, UserManager<GeoUser> userManager)
        {
            SeedComments(context);
            SeedUsers(userManager);
        }

        private static void SeedComments(GeoMessageContext context)
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

        private static void SeedUsers(UserManager<GeoUser> userManager)
        {
            GeoUser user = new GeoUser();
            user.UserName = "TestUser";
    
            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;
        }
    }
}
