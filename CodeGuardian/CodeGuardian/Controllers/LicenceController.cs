using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using License = CodeGuardian.DOMAINE.Entity.License;

namespace CodeGuardian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly ILicenceService _licenceService;

        public LicenseController(ILicenceService licenceService)
        {
            this._licenceService = licenceService;
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
    }
}