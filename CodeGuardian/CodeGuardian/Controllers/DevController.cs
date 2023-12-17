using CodeGuardian.DOMAIN.Entity.Users.Dev;
using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeGuardian.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DevController : Controller
    {
        private readonly IDevService _userService;
        private readonly ILicenceService _licenceService;
        private readonly IApplicationService _applicationService;

        public DevController(IDevService userService, ILicenceService licenceService, IApplicationService applicationService)
        {
            this._userService = userService;
            this._licenceService = licenceService;
            this._applicationService = applicationService;
        }

        /// <summary>
        /// Route to get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user/{userId}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                Dev userToFind = _userService.GetuserByID(userId);
                return Ok(userToFind);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        ///// <summary>
        ///// Route to verify the user application licence key
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <param name="appid"></param>
        ///// <param name="licenseKey"></param>
        ///// <returns></returns>
        //[HttpGet("user/{userId}/application/{appid}/verify/licencekey/{licenseKey}")]
        //[Authorize(Roles = "Admin,User")]
        //public IActionResult CheckUserApplicationLicenceKey(int userId, int appid, string licenseKey)
        //{
        //    try
        //    {
        //        List<Application> userApplications = _userService.CheckUserApplicationLicenceKey(userId, appid, licenseKey);
        //        return Ok(userApplications);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}
    }
}