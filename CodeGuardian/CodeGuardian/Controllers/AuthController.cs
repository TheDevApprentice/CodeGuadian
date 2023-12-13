using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodeGuardian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILicenceService _licenceService;
        private readonly IApplicationService _applicationService;

        public AuthController(IUserService userService, ILicenceService licenceService, IApplicationService applicationService)
        {
            this._userService = userService;
            this._licenceService = licenceService;
            this._applicationService = applicationService;
        }

        [HttpPost("createtoken")]
        public async Task<IActionResult> CreateToken(string login)
        {
            var token = GenerateJwtToken(login);

            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(string user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your-secret-key-with-at-least-128-bits");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "your-audience",
                Issuer = "your-issuer",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user),
                    new Claim(ClaimTypes.Role, "User"),

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}