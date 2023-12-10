using CodeGuardian.API.DTO;
using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;
using CodeGuardian.INFRA;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
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
        public IActionResult GetAllUsers()
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