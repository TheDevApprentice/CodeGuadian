using CodeGuardian.API.DTO;
using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeGuardian.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAdministratorService _administratorService;

        public PersonController(IUserService userService, IAdministratorService administratorService)
        {
            this._userService = userService;
            this._administratorService = administratorService;
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            try
            {
                List<User> users = _userService.GetAllUsers();

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("user/name")]
        public IActionResult GetUserByName([FromQuery] string username)
        {
            try
            {
                User userToFind = _userService.GetAnUserByName(username);

                return Ok(userToFind);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("user")]
        public IActionResult AddAnUser([FromBody] UserDTO userToAdd)
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