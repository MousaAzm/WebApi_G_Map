using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_G_Map.Data;
using WebApi_G_Map.Models;

namespace WebApi_G_Map.Controllers.v2._0
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class GeoMessageController : ControllerBase
    {
        private readonly GeoMessageContext _context;

        public GeoMessageController(GeoMessageContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeoCommentsV2>>> GetMessage()
        {
            return await _context.GeoMessagesV2.Select(m =>
            m.ToComments()).ToListAsync();
        }

        //[Authorize]
        //[HttpPost]
        //public async Task<ActionResult<GeoCommentsV2>> PostMessage(GeoCommentsV2 message)
        //{

        //    var gm = message.ToModel();
        //    _context.GeoMessagesV2.Add(gm);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMessage", new { id = gm.Id }, message);

        //}
    }
}
