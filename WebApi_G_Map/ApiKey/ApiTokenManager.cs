using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiKey;
using ApiKey.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi_G_Map.Data;
using WebApi_G_Map.Models;

namespace ApiKey.ApiKey
{
    public class ApiTokenManager
    {

        private readonly GeoMessageContext _context;

        public ApiTokenManager(GeoMessageContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateTokenAsync(GeoUser user, string token=null)
        {
            var apiToken = await _context.ApiTokens
                .FirstOrDefaultAsync(t => t.User.Id == user.Id);

            apiToken ??= new ApiToken();

            apiToken.Value = token ?? Guid.NewGuid().ToString();
            apiToken.User = user;

            _context.ApiTokens.Update(apiToken);
            await _context.SaveChangesAsync();

            return apiToken.Value;
        }

        public async Task<GeoUser> GetUserByTokenAsync(string token)
        {
            return await _context.ApiTokens.Where(t => t.Value == token)
                .Select(t => t.User)
                .FirstOrDefaultAsync();
        }
    }
}
