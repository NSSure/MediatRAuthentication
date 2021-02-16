using AttributeInjection.Models;
using AttributeInjection.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly TokenManagement _tokenManagement;

        public AccountController(IOptions<TokenManagement> tokenManagement)
        {
            this._tokenManagement = tokenManagement.Value;
        }

        [HttpGet("login")]
        public async Task<ActionResult> Login()
        {
            try
            {
                string token = string.Empty;

                var claim = new[]
                {
                    new Claim("name", "admin")
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var jwtToken = new JwtSecurityToken(
                    _tokenManagement.Issuer,
                    _tokenManagement.Audience,
                    claim,
                    expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                    signingCredentials: credentials
                );

                token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                return StatusCode(200, token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
