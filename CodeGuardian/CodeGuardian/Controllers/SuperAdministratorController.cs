using CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;
using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeGuardian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAdministratorController : ControllerBase
    {
        private readonly ISuperAdministratorService _superAdministratorService;

        public SuperAdministratorController(
            ISuperAdministratorService superAdministratorService)
        {
            this._superAdministratorService = superAdministratorService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Organisations")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult GetAllOrganisations()
        {
            try
            {
                List<Organisation> permissions = _superAdministratorService.GetAllOrganisations();

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
        [HttpPut("Organisation/{organisationId}")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult ModifyOrganisation(Guid organisationId)
        {
            try
            {
                List<Organisation> permissions = _superAdministratorService.GetAllOrganisations();

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
        [HttpDelete("Organisation/{organisationId}")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult DeleteOrganisation(Guid organisationId)
        {
            try
            {
                List<Organisation> permissions = _superAdministratorService.GetAllOrganisations();

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
        [HttpGet("Organisation/{organisationId}/devs")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult GetOrganisationDevs()
        {
            try
            {
                List<Organisation> permissions = _superAdministratorService.GetAllOrganisations();

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
        [HttpGet("Organisation/{organisationId}/dev/{devId}")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult GetOrganisationDevById(Guid organisationId, Guid devId)
        {
            try
            {
                List<Organisation> permissions = _superAdministratorService.GetAllOrganisations();

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
        [HttpPost("Organisation/{organisationId}/dev")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult CreateOrganisationDev(Guid organisationId) // create OrganisationDevDTO
        {
            try
            {
                List<Organisation> permissions = _superAdministratorService.GetAllOrganisations();

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
        [HttpPut("Organisation/{organisationId}/dev/{devId}")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult ModifyOrganisationDev(Guid organisationId, Guid devId)
        {
            try
            {
                List<Organisation> permissions = _superAdministratorService.GetAllOrganisations();

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
        [HttpDelete("Organisation/{organisationId}/dev/{devId}")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult DeleteOrganisationDev(Guid organisationId, Guid devId)
        {
            try
            {
                List<Organisation> permissions = _superAdministratorService.GetAllOrganisations();

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
        [HttpPost("Organisation/{organisationId}/app")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult RegisterAppForOrganisation(Guid organisationId) // OrganisationApplicationDTo to create
        {
            try
            {
                List<Organisation> permissions = _superAdministratorService.GetAllOrganisations();

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
        [HttpPut("Organisation/{organisationId}/app/{appId}")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult ModifyOrganisationApp(Guid organisationId, Guid appId) // OrganisationApplicationDTo to create
        {
            try
            {
                List<Organisation> permissions = _superAdministratorService.GetAllOrganisations();

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
        [HttpDelete("Organisation/{organisationId}/app/{appId}")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult DeleteOrganisationApp(Guid organisationId, Guid appId) // OrganisationApplicationDTo to create
        {
            try
            {
                List<Organisation> permissions = _superAdministratorService.GetAllOrganisations();

                return Ok(permissions);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}