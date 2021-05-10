using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<GeoUser> _userManager;
        
        public GeoMessageController(GeoMessageContext context, UserManager<GeoUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
           /// <summary>
           /// Ange min och maxvärde för den kommentar du vill hämta, lämnas något fält tomt hämtas alla kommentarer.
           /// </summary>
           /// <param name="minLon"></param>
           /// <param name="minLat"></param>
           /// <param name="maxLon"></param>
           /// <param name="maxLat"></param>
           /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeoMessageV2>>> GetMessage(double minLon, double minLat, double maxLon,double maxLat)
        {
            if (minLon == 0 || minLat == 0 || maxLon == 0 || maxLat == 0)
            {
                return await _context.GeoMessagesV2.Include(m => m.Message).ToListAsync();
            }

            return await _context.GeoMessagesV2
                .Include(m => m.Message)
                .Where(c => 
                (c.latitude <= maxLat &&
                c.latitude >= minLat) &&
                (c.longitude <= maxLon && 
                c.longitude >= minLon))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeoMessageV2>> GetMessage(int id)
        {
            var mess = await _context.GeoMessagesV2.FindAsync(id);

            if (mess == null)
            {
                return NotFound();
            }

            var message = await _context.GeoMessagesV2.
                Where(e => e.Id == id)
                .Include(m => m.Message)
                .FirstOrDefaultAsync();
            return (message);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<GeoMessageV2>> PostMessage(GeoMessageV2 message)
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.Users
                .Where(u => u.Id == userId)
                .Include(m => m.GeoMessagesV2)
                .FirstOrDefault();

            message.Message.author = user.FirstName + " " + user.LastName;

            user.GeoMessagesV2.Add(message);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = message.Id }, message);

        }
    }
}
