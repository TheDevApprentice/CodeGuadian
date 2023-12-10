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
        public IActionResult GetAllUsers()
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