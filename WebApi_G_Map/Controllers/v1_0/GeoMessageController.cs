using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_G_Map.Data;
using WebApi_G_Map.Models;

namespace WebApi_G_Map.Controllers.v1_0
{
    [ApiVersion("1.0")]
    [Route("api/v{version = ApiVersion}/[controller]")]
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
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeoCommentsV1>>> GetMessage()
        {
            return await _context.GeoMessagesV1.Select(m =>
            m.ToComments()).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<GeoCommentsV1>> GetMessage(int id)
        {
            var ms = await _context.GeoMessagesV1.FindAsync(id);
            
            if (ms == null)
            {
                return NotFound();
            }
            var res = new GeoCommentsV1
            {
                message = ms.message,
                Lognitude = ms.Lognitude,
                latitude = ms.latitude
            };
            return(res);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<GeoCommentsV1>> PostMessage(GeoCommentsV1 message)
        {

            var gm = message.ToModel();
            _context.GeoMessagesV1.Add(gm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = gm.Id }, message);

        }
    }
}