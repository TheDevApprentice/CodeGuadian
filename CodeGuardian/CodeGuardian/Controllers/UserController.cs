using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeGuardian.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILicenceService _licenceService;
        private readonly IApplicationService _applicationService;

        public UserController(IUserService userService, ILicenceService licenceService, IApplicationService applicationService)
        {
            this._userService = userService;
            this._licenceService = licenceService;
            this._applicationService = applicationService;
        }

        /// <summary>
        /// Route to get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet("users")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetAllUsers()
        {
            try
            {
                List<User> users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Route to get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user/{userId}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                User userToFind = _userService.GetuserByID(userId);
                return Ok(userToFind);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Route to get all user applications
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user/{userId}/applications")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetUserApplications(int userId)
        {
            try
            {
                List<Application> userApplications = _userService.GetUserApplications(userId);
                return Ok(userApplications);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Route to allow an user to register to an app
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="appid"></param>
        /// <returns></returns>
        [HttpPost("user/{userId}/application/register/{appid}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult RegisterForApp(int userId, Guid appUuid)
        {
            try
            {
                List<Application> userApplications = _userService.GetUserApplications(userId); // a changer
                return Ok(userApplications);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Route to verify the user application licence key
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="appid"></param>
        /// <param name="licenseKey"></param>
        /// <returns></returns>
        [HttpGet("user/{userId}/application/{appid}/verify/licencekey/{licenseKey}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult CheckUserApplicationLicenceKey(int userId, int appid, string licenseKey)
        {
            try
            {
                List<Application> userApplications = _userService.CheckUserApplicationLicenceKey(userId, appid, licenseKey);
                return Ok(userApplications);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}