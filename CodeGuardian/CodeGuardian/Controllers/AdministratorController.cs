using CodeGuardian.API.DTO;
using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;
using CodeGuardian.DOMAINE.Services;
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