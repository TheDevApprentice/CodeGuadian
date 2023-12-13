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

        [HttpGet("users")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUserss()
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

        [HttpPost("application")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddApplication()
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

        [HttpPut("application")]
        [Authorize(Roles = "Admin")]
        public IActionResult ModifyApplication()
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

        [HttpDelete("application")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteApplication()
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

        [HttpGet("licences")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllLicences()
        {
            try
            {
                List<License> users = _licenceService.GetAllLicenses();

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("licence")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddLicence()
        {
            try
            {
                List<License> users = _licenceService.GetAllLicenses();

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("licence")]
        [Authorize(Roles = "Admin")]
        public IActionResult ModifyLicence()
        {
            try
            {
                List<License> users = _licenceService.GetAllLicenses();

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("licence")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteLicence()
        {
            try
            {
                List<License> users = _licenceService.GetAllLicenses();

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("permissions")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAlPermissions()
        {
            try
            {
                List<Permission> users = _permissionService.GetAlPermissions();

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("permission")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddPermission()
        {
            try
            {
                List<Permission> users = _permissionService.GetAlPermissions();

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("permission")]
        [Authorize(Roles = "Admin")]
        public IActionResult ModifyPermission()
        {
            try
            {
                List<Permission> users = _permissionService.GetAlPermissions();

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("permission")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeletePermission()
        {
            try
            {
                List<Permission> users = _permissionService.GetAlPermissions();

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}