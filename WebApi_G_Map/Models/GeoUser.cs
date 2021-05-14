using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WebApi_G_Map.Models
{
    public class GeoUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<GeoMessageV1> GeoMessagesV1 { get; set; }
        public ICollection<GeoMessageV2> GeoMessagesV2 { get; set; }
    }
}
