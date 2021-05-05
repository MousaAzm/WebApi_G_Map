using Microsoft.AspNetCore.Identity;
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

            var mess = new GeoMessageV1[]
            {
                new GeoMessageV1
                {
                    messagae = "Hej",
                    Lognitude = 12.537346634870165,
                    latitude = 56.99912460665679
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
