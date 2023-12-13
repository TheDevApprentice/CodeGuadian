using CodeGuardian.API.DTO;
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
        private readonly ILicenceService _licenceService;
        private readonly IApplicationService _applicationService;
        private readonly Auth _auth;

        public UserAccountController(IUserService userService, ILicenceService licenceService, IApplicationService applicationService)
        {
            this._userService = userService;
            this._licenceService = licenceService;
            this._applicationService = applicationService;
            _auth = new Auth();
        }

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

        [Authorize(Roles = "Admin,User")]
        [HttpGet("user/account/disconnect/user/{email}/password/{password}")]
        public IActionResult Disconnect(string email, string password)
        {
            try
            {
                //User user = _userService.Disconnect();
                //_auth

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("user/account/create")]
        public IActionResult CreateUserAccount([FromBody] UserDTO userDTO)
        {
            try
            {
                //User user = _userService.CreateUserAccount(userDTO);
                //_auth.GenerateJwtTemporaryToken(userDTO)

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("user/account/forgot/{email}")]
        public IActionResult UserForgotAccountCredentials(string email)
        {
            try
            {
                //User userToFind = _userService.GetuserByID(userId);
                //return Ok(userToFind);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("user/account/Recover/{email}/{username}/uuid/{uuid}")]
        [Authorize(Roles = "Temp")]
        public IActionResult UserRecoverLostAccount(string email, string username, Guid guid)
        {
            try
            {
                //User userToFind = _userService.GetuserByID(userId);
                //return Ok(userToFind);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [Authorize(Roles = "Admin,User")]
        [HttpDelete("user/account/{userId}/email/{email}")]
        public IActionResult DeleteUserAccount(int userId, string email)
        {
            try
            {
                //List<User> users = _userService.GetAllUsers();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}