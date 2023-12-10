using CodeGuardian.API.DTO;
using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeGuardian.API.Controllers
{
    public class AdministratorController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AdminController : ControllerBase
        {
            private readonly IAdministratorService _administratorService;

            public AdminController(IAdministratorService administratorService)
            {
                this._administratorService = administratorService;
            }

            //[HttpPost("register/admin")]
            //public IActionResult RegisterAdmin([FromBody] AdministratorDTO admin)
            //{
            //    // Ajoutez la logique pour enregistrer un nouvel administrateur
              
            //    return Ok();
            //}

            [HttpPost("register/user")]
            public IActionResult RegisterUser([FromBody] UserDTO userToAdd)
            {
                try
                {
                    _administratorService.AddAnUser(new User()
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
        }

    }
}
