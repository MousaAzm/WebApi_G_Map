using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_G_Map.Data;
using WebApi_G_Map.Models;

namespace WebApi_G_Map.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GeoMessageController : ControllerBase
    {
        private readonly GeoMessageContext _context;

        public GeoMessageController(GeoMessageContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeoComments>>> Get()
        {
            return await _context.GeoMessages.Select(m => m.ToComments()).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeoComments>> GetMessage(int id)
        {
            var ms = await _context.GeoMessages.FindAsync(id);

            if (ms == null)
            {
                return NotFound();
            }

            return ms.ToComments();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<GeoComments>> PostMessage(GeoComments mes)
        {

            var gm = mes.ToModel();
            _context.GeoMessages.Add(gm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = gm.Id }, mes);

        }

    }
}
