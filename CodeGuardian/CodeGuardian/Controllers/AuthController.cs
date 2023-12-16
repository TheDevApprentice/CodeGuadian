using Microsoft.AspNetCore.Mvc;

namespace CodeGuardian.API.Controllers
{
#if DEBUG
    /// <summary>
    /// For testingOnly
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly Auth _auth;

        public AuthController()
        {
            this._auth = new Auth();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("createtokenuser")]
        public async Task<IActionResult> CreateTokenUser(string? login)
        {
            if (login is null)
            {
                return BadRequest("Le param�tre 'login' ne peut pas �tre null.");
            }

            var token = _auth.GenerateJwtToken(login, "User");
            return Ok(new { Token = token });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("createtokenapplication")]
        public async Task<IActionResult> CreateTokenApplication(string? applicationUuidEncrypted)
        {
            if (applicationUuidEncrypted is null)
            {
                return BadRequest("Le param�tre 'login' ne peut pas �tre null.");
            }

            var token = _auth.GenerateJwtToken(applicationUuidEncrypted, "Application");
            return Ok(new { Token = token });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("createtokenadmin")]
        public async Task<IActionResult> CreateTokenAdmin(string? login)
        {
            if (login is null)
            {
                return BadRequest("Le param�tre 'login' ne peut pas �tre null.");
            }

            var token = _auth.GenerateJwtToken(login, "Admin");
            return Ok(new { Token = token });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("createtokenusertemp")]
        public async Task<IActionResult> CreateTokenTemp(string? login)
        {
            if (login is null)
            {
                return BadRequest("Le param�tre 'login' ne peut pas �tre null.");
            }

            var token = _auth.GenerateJwtToken(login, "Temp");
            return Ok(new { Token = token });
        }
    }
#endif
}