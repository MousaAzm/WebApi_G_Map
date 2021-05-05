using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi_G_Map.Models;

namespace WebApi_G_Map.Data
{
    public class GeoMessageContext : IdentityDbContext<GeoUser>
    {
        public GeoMessageContext(DbContextOptions<GeoMessageContext> options)
            : base(options)
        {

        }

        public DbSet<GeoMessageV1> GeoMessagesV1 { get; set; }
        public DbSet<GeoMessageV2> GeoMessagesV2 { get; set; }

    }
}
