﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_G_Map.Model
{
    public class GeoMessage
    {
        public int Id { get; set; }
        public string message { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
    }
}
