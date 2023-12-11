using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeGuardian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            this._permissionService = permissionService;
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