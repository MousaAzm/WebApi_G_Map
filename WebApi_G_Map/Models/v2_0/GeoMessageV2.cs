﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebApi_G_Map.Models;

namespace WebApi_G_Map.Models
{
    public class GeoMessageV2 
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public GeoUser GeoUsers { get; set; }

        public double longitude { get; set; }

        public double latitude { get; set; }

        public Message Message { get; set; }

    }

}
