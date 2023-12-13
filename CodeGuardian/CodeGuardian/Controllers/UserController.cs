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

        [HttpPost("user/{userId}/application/register/{appid}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult RegisterForApp(int userId, int appid)
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