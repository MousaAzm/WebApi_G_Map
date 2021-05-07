using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_G_Map.Models.v2_0
{
    public class Message
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
    }
}
