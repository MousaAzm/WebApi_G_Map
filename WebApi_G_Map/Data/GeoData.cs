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
                    message = "Hello",
                    longitude = 12.62089088500265,
                    latitude = 57.03307860715982
                },
                new GeoMessageV1
                {
                    message = "Hi",
                    longitude = 13.556586486486488,
                    latitude = 56.7286244026493
                },
                new GeoMessageV1
                {
                    message = "Hi everyone",
                    longitude = 12.240764546899841,
                    latitude = 56.68901140206243
                },
                new GeoMessageV1
                {
                    message = "Hej",
                    longitude = 13.184814573396928,
                    latitude = 57.41109981276025
                }
            };

            var messV2 = new GeoMessageV2[]
            {
                new GeoMessageV2
                {
                    Message = new Message{author = "Björn", title = "title", body = "body"},
                    longitude = 1,
                    latitude = 10
                },
                new GeoMessageV2
                {
                    Message = new Message{author = "yes", title = "title", body = "body"},
                    longitude = 1,
                    latitude = 12
                },
                new GeoMessageV2
                {
                    Message = new Message{author = "test", title = "title", body = "body"},
                    longitude = 1,
                    latitude = 13
                }
            };

            context.AddRange(messV1);
            context.AddRange(messV2);
            context.SaveChanges();

        }

        private static void SeedUsers(UserManager<GeoUser> userManager)
        {
            GeoUser user = new GeoUser();
            user.UserName = "TestUser";
            user.FirstName = "bob";
            user.LastName = "bobsson";

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;
        }
    }
}
