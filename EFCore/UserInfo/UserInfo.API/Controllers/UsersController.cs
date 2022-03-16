using Microsoft.AspNetCore.Mvc;
using UserInfo.API.Models;

namespace UserInfo.API.Controllers
{
    //ControllerBase : Contains basic functionality controllers need like access to model state,
    //the current user and common methods for returning responses.
    //Controller : Contains addition methods when returning views which is not need when building an API

    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UsersDataStore _usersDataStore;
        public UsersController(UsersDataStore usersDataStore)
        {
            _usersDataStore = usersDataStore ?? throw new ArgumentNullException(nameof(usersDataStore));
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        { 
            return Ok (_usersDataStore.Users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetCity(int id)
        {
            //find a users
            var userToReturn = _usersDataStore.Users
                .FirstOrDefault(c => c.Id == id);

            if (userToReturn == null)
            {
                return NotFound();
            }

            return Ok(userToReturn);
        }
    }
}
