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
                    message = "Hello_V1",
                    longitude = 12.62089088500265,
                    latitude = 57.03307860715982
                },
                new GeoMessageV1
                {
                    message = "Hi_V1",
                    longitude = 13.556586486486488,
                    latitude = 56.7286244026493
                },
                new GeoMessageV1
                {
                    message = "Hi everyone_V1",
                    longitude = 12.240764546899841,
                    latitude = 56.68901140206243
                },
                new GeoMessageV1
                {
                    message = "Hej_V1",
                    longitude = 13.184814573396928,
                    latitude = 57.41109981276025
                }
            };

            var messV2 = new GeoMessageV2[]
            {
                new GeoMessageV2
                {
                    Message = new Message{author = "Björn", title = "title_test1_V2", body = "body_test1_V2"},
                    longitude = 16.376738473767887,
                    latitude = 59.02998082329598
                },
                new GeoMessageV2
                {
                    Message = new Message{author = "Mousa", title = "title_test2_V2", body = "body_test2_V2"},
                    longitude = 15.849909856915739,
                    latitude = 59.83433435430232
                },
                new GeoMessageV2
                {
                    Message = new Message{author = "Anton", title = "title_test3_V2", body = "body_test3_V2"},
                    longitude = 16.98617631160572,
                    latitude = 59.66414368275438
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
