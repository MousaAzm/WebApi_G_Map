using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_G_Map.Models;

namespace ApiKey.Models
{
    public class ApiToken
    {
        public int Id { get; set; }
        public GeoUser User { get; set; }
        public string Value { get; set; }
    }
}
