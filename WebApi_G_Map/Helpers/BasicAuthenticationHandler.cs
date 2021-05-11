using ApiKey.ApiKey;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using WebApi_G_Map.Models;

namespace WebApi_G_Map.Helpers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly UserManager<GeoUser> _userManager;

        private readonly ApiTokenManager _apiTokenManager;

        public BasicAuthenticationHandler(
             IOptionsMonitor<AuthenticationSchemeOptions> options,
             ILoggerFactory logger,
             UrlEncoder encoder,
             ISystemClock clock,
             ApiTokenManager apiTokenManager,
             UserManager<GeoUser> userManager)
             : base(options, logger, encoder, clock)
        {
            _userManager = userManager;
            _apiTokenManager = apiTokenManager;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            GeoUser user;
            string password;

            string token = Request.Query["ApiKey"];
            if (token == null)
            {
                var endpoint = Context.GetEndpoint();
                if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
                    return AuthenticateResult.NoResult();

                if (!Request.Headers.ContainsKey("Authorization"))
                    return AuthenticateResult.Fail("Missing Authorization Header");

                try
                {
                    
                    var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                    var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                    var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                    var username = credentials[0];
                    password     = credentials[1];
                    user = await _userManager.FindByNameAsync(username);

                    if (user == null || password == null || await _userManager.CheckPasswordAsync(user, password) == false)
                        return AuthenticateResult.Fail("Invalid Username or Password");
                }
                catch
                {
                    return AuthenticateResult.Fail("Invalid Authorization Header");
                }
            }
            else
            {
                user = await _apiTokenManager.GetUserByTokenAsync(token);
            }

            if (user == null)
                return AuthenticateResult.Fail("Invalid User");

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
