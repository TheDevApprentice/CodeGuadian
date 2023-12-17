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
        private readonly IExcelLogger _excelLogger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelLogger"></param>
        public AuthController(IExcelLogger excelLogger)
        {
            this._auth = new Auth();
            this._excelLogger = excelLogger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("createtokenuser")]
        public async Task<IActionResult> CreateTokenUser(string? login)
        {
            _excelLogger.LogMessage($"User : {login} desire a token for user"); 
            if (login is null)
            {
                return BadRequest("Le paramètre 'login' ne peut pas être null.");
            }

            var token = _auth.GenerateJwtToken(login, "User");
            if (token != null)
            {
                _excelLogger.LogMessage($"Token : {token} generated.");
            }
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
            _excelLogger.LogMessage($"Application : {applicationUuidEncrypted} desire a token");
            if (applicationUuidEncrypted is null)
            {
                return BadRequest("Le paramètre 'login' ne peut pas être null.");
            }

            var token = _auth.GenerateJwtToken(applicationUuidEncrypted, "Application");
            if (token != null)
            {
                _excelLogger.LogMessage($"Token : {token} generated. for {applicationUuidEncrypted}");
            }
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
            _excelLogger.LogMessage($"User : {login} desire a token for user");
            if (login is null)
            {
                return BadRequest("Le paramètre 'login' ne peut pas être null.");
            }

            var token = _auth.GenerateJwtToken(login, "Admin");
            if (token != null)
            {
                _excelLogger.LogMessage($"Token : {token} generated.");
            }
            return Ok(new { Token = token });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("createtokensuperadmin")]
        public async Task<IActionResult> CreateTokenSuperAdmin(string? login)
        {
            _excelLogger.LogMessage($"User : {login} desire a token for user");
            if (login is null)
            {
                return BadRequest("Le paramètre 'login' ne peut pas être null.");
            }

            var token = _auth.GenerateJwtToken(login, "Admin");
            if (token != null)
            {
                _excelLogger.LogMessage($"Token : {token} generated.");
            }
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
            _excelLogger.LogMessage($"User : {login} desire a token for user");
            if (login is null)
            {
                return BadRequest("Le paramètre 'login' ne peut pas être null.");
            }

            var token = _auth.GenerateJwtToken(login, "Temp");
            if (token != null)
            {
                _excelLogger.LogMessage($"Token : {token} generated.");
            }
            return Ok(new { Token = token });
        }
    }
#endif
}