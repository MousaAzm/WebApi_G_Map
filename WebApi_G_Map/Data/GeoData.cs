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

            var messV1 = new GeoMessageV1[]
            {

                new GeoMessageV1
                {
                    message = "",
                    Lognitude = 0,
                    latitude = 0
                },
                new GeoMessageV1
                {
                    message = "",
                    Lognitude = 0,
                    latitude = 0
                },
                new GeoMessageV1
                {
                    message = "",
                    Lognitude = 0,
                    latitude = 0
                },
                new GeoMessageV1
                {
                    message = "",
                    Lognitude = 0,
                    latitude = 0
                }
            };
            var mess = new Message
            {
                Author = "anton",
                Title = "titel",
                Body = "kropp"

            };
            var messV2 = new GeoMessageV2[]
            {

                new GeoMessageV2
                {
                    Message = mess,
                    Lognitude = 0,
                    latitude = 0
                }};

            context.AddRange(messV2);
            context.AddRange(messV1);
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
