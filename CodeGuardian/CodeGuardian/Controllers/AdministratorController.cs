using CodeGuardian.API.DTO;
using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeGuardian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IAdministratorService _administratorService;
        private readonly IUserService _userService;
        private readonly IApplicationService _applicationService;
        private readonly ILicenceService _licenceService;
        private readonly IPermissionService _permissionService;

        public AdministratorController(
            IAdministratorService administratorService,
            IUserService userService,
            IApplicationService applicationService,
            ILicenceService licenceService,
            IPermissionService permissionService)
        {
            this._userService = userService;
            this._administratorService = administratorService;
            this._applicationService = applicationService;
            this._permissionService = permissionService;
            this._licenceService = licenceService;
        }

        /// <summary>
        /// Admin route to get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet("users")]
        [Authorize(Roles = "Admin")]
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
        /// Admin route to get all users by name
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("user/name")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetUserByNames([FromQuery] string username)
        {
            try
            {
                User userToFind = _userService.GetAnUserByName(username);

                return Ok(userToFind);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Admin route to add an user
        /// </summary>
        /// <param name="userToAdd"></param>
        /// <returns></returns>
        [HttpPost("user")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddAnUser([FromBody] UserDTO userToAdd)
        {
            try
            {
                _administratorService.AddAnuser(new User()
                {
                    FirstName = userToAdd.FirstName,
                    LastName = userToAdd.LastName,
                    IsAdmin = userToAdd.IsAdmin
                });

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Admin route to get all applications
        /// </summary>
        /// <returns></returns>
        [HttpGet("applications")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllApplications()
        {
            try
            {
                List<Application> users = _applicationService.GetAllApplication();

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("application")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddApplication()
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
        /// <returns></returns>
        [HttpPut("application")]
        [Authorize(Roles = "Admin")]
        public IActionResult ModifyApplication()
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
        /// <returns></returns>
        [HttpDelete("application")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteApplication()
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
        /// <returns></returns>
        [HttpGet("licences")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllLicences()
        {
            try
            {
                List<License> licences = _licenceService.GetAllLicenses();

                return Ok(licences);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("licence")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddLicence()
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
        /// <returns></returns>
        [HttpPut("licence")]
        [Authorize(Roles = "Admin")]
        public IActionResult ModifyLicence()
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
        /// <returns></returns>
        [HttpDelete("licence")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteLicence()
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
        /// <returns></returns>
        [HttpGet("permissions")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAlPermissions()
        {
            try
            {
                List<Permission> permissions = _permissionService.GetAlPermissions();

                return Ok(permissions);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("permission")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddPermission()
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
        /// <returns></returns>
        [HttpPut("permission")]
        [Authorize(Roles = "Admin")]
        public IActionResult ModifyPermission()
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
        /// <returns></returns>
        [HttpDelete("permission")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeletePermission()
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