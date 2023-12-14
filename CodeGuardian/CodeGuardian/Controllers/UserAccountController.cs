using CodeGuardian.API.DTO;
using CodeGuardian.DOMAINE.Authentification;
using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeGuardian.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserAccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthService _auth;

        public UserAccountController(IUserService userService, IAuthService authService)
        {
            this._userService = userService;
            this._auth = authService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("user/account/connect/user/{email}/password/{password}")]
        public IActionResult Connect(string email, string password)
        {
            try
            {
                //List<User> users = _userService.Connect();
                //_auth
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,User")]
        [HttpGet("user/account/disconnect/user/{email}/password/{password}")]
        public IActionResult Disconnect(string email, string password)
        {
            try
            {

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost("user/account/create")]
        public IActionResult CreateUserAccount([FromBody] UserDTO userDTO)
        {
            try
            {

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("user/account/forgot/{email}")]
        public IActionResult UserForgotAccountCredentials(string email)
        {
            try
            {

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// A route that allow verified user to recover their account
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet("user/account/Recover/{email}/{username}/uuid/{uuid}")]
        [Authorize(Roles = "Temp")]
        public IActionResult UserRecoverLostAccount(string email, string username, Guid guid)
        {
            try
            {

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,User")]
        [HttpDelete("user/account/{userId}/email/{email}")]
        public IActionResult DeleteUserAccount(int userId, string email)
        {
            try
            {

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}