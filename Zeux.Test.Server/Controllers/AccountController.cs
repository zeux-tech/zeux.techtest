using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Zeux.Test.Server.Models.Account;
using Zeux.Test.Services;

namespace Zeux.Test.Server.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        private readonly IOptions<AuthOptions> authOptions;

        public AccountController(IUserService userService, IOptions<AuthOptions> authOptions)
        {
            this.userService = userService;
            this.authOptions = authOptions;
        }

        [HttpPost("/token")]
        public async Task<IActionResult> Token([FromBody] TokenModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetIdentity(model.Username, model.Password);
            if (identity == null)
            {
                return BadRequest("Invalid username or password.");
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: authOptions.Value.Issuer,
                    audience: authOptions.Value.Audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(authOptions.Value.Lifetime)),
                    signingCredentials: new SigningCredentials(authOptions.Value.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            Response.Cookies.Append("jwt-token", encodedJwt);
            Response.Cookies.Append("jwt-user", identity.Name);

            return Json(new
            {
                token = encodedJwt,
                username = identity.Name
            });
        }

        private async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            var person = await userService.FindUser(username, password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };

                return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            }

            return null;
        }
    }
}