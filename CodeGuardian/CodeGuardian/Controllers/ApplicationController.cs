using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using License = CodeGuardian.DOMAINE.Entity.License;

namespace CodeGuardian.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ApplicationController : Controller
    {
        private readonly ILicenceService _licenceService;
        private readonly IApplicationService _applicationService;

        public ApplicationController(ILicenceService licenceService, IApplicationService applicationService)
        {
            this._licenceService = licenceService;
            this._applicationService = applicationService;
        }

        /// <summary>
        /// Route to verify the user application licence key
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="appid"></param>
        /// <param name="licenseKeyhash"></param>
        /// <returns></returns>
        [HttpGet("application/licence/{licenseKeyhash}")]
        [Authorize(Roles = "Application")]
        public IActionResult CheckUserApplicationLicenceKey(string licenseKeyhash)
        {
            try
            {
                License userApplications = _applicationService.CheckApplicationLicenceKey(licenseKeyhash);
                return Ok(userApplications);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}