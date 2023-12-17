using CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;
using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeGuardian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        private readonly IOrganisationService _organisationService;


        public OrganisationController(
            IOrganisationService organisationService)
        {
            this._organisationService = organisationService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut("{organisationId}")]
        [Authorize(Roles = "Organisation")]
        public IActionResult ModifyOrganisation(Guid organisationId)
        {
            try
            {
                List<Organisation> permissions = _organisationService.GetAllOrganisations();

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
        [HttpGet("{organisationId}/devs")]
        [Authorize(Roles = "Organisation")]
        public IActionResult GetOrganisationDevs()
        {
            try
            {
                List<Organisation> permissions = _organisationService.GetAllOrganisations();

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
        [HttpGet("{organisationId}/dev/{devId}")]
        [Authorize(Roles = "Organisation")]
        public IActionResult GetOrganisationDevById(Guid organisationId, Guid devId)
        {
            try
            {
                List<Organisation> permissions = _organisationService.GetAllOrganisations();

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
        [HttpPost("{organisationId}/dev")]
        [Authorize(Roles = "Organisation")]
        public IActionResult CreateOrganisationDev(Guid organisationId) // create OrganisationDevDTO
        {
            try
            {
                List<Organisation> permissions = _organisationService.GetAllOrganisations();

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
        [HttpPut("{organisationId}/dev/{devId}")]
        [Authorize(Roles = "Organisation")]
        public IActionResult ModifyOrganisationDev(Guid organisationId, Guid devId)
        {
            try
            {
                List<Organisation> permissions = _organisationService.GetAllOrganisations();

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
        [HttpDelete("{organisationId}/dev/{devId}")]
        [Authorize(Roles = "Organisation")]
        public IActionResult DeleteOrganisationDev(Guid organisationId, Guid devId)
        {
            try
            {
                List<Organisation> permissions = _organisationService.GetAllOrganisations();

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
        [HttpPost("{organisationId}/app")]
        [Authorize(Roles = "Organisation")]
        public IActionResult RegisterAppForOrganisation(Guid organisationId) // OrganisationApplicationDTo to create
        {
            try
            {
                List<Organisation> permissions = _organisationService.GetAllOrganisations();

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
        [HttpPut("{organisationId}/app/{appId}")]
        [Authorize(Roles = "Organisation")]
        public IActionResult ModifyOrganisationApp(Guid organisationId, Guid appId) // OrganisationApplicationDTo to create
        {
            try
            {
                List<Organisation> permissions = _organisationService.GetAllOrganisations();

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
        [HttpDelete("{organisationId}/app/{appId}")]
        [Authorize(Roles = "Organisation")]
        public IActionResult DeleteOrganisationApp(Guid organisationId, Guid appId) // OrganisationApplicationDTo to create
        {
            try
            {
                List<Organisation> permissions = _organisationService.GetAllOrganisations();

                return Ok(permissions);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}