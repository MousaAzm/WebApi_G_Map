using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_G_Map.Models;

namespace WebApi_G_Map.Data
{
    public class GeoMessageContext : DbContext
    {
        public GeoMessageContext(DbContextOptions<GeoMessageContext> options)
            : base(options)
        {

        }

        public DbSet<GeoMessage> GeoMessages { get; set; }

    }
}
