using CodeGuardian.API.DTO;
using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;
using CodeGuardian.INFRA;
using Microsoft.AspNetCore.Mvc;

namespace CodeGuardian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            this._applicationService = applicationService;
        }

        [HttpGet("applications")]
        public IActionResult GetAllUsers()
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
    }
}
