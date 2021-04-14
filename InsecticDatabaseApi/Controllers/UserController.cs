using Microsoft.AspNetCore.Mvc;
using InsecticDatabaseApi.InsecticData;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.Controllers
{
    
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserData _userData;

        public UserController(IUserData user)
        {
            _userData = user;
        }

       
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userData.GetAllUsers());
        }


        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _userData.GetUser(id);

            if (user == null)
            {
                return NotFound($"User with Id of {id} does not exist");
            }
            return Ok(_userData.GetUser(id));
        }

        [HttpGet]
        [Route("api/[controller]/ForSupervisor{supervisor}")]
        public IActionResult GetUsersOfSupervisor(string supervisorId)
        {
            var user = _userData.GetUser(supervisorId);

            if (user == null)
            {
                return NotFound($"Supervisor with Id of {supervisorId} does not exist");
            }
            return Ok(_userData.GetUsersBySupervisor(supervisorId));
        }

        //todo: add table for resource group and implement resource groups
        [HttpGet]
        [Route("api/[controller]/ForGroup{group}")]
        public IActionResult GetUsersOfResourceGroup(string group)
        {
            return Ok(_userData.GetUserByResourceGroup(group));
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddUser(User newUser)
        {
            _userData.AddUser(newUser);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + newUser.UserId, newUser);
        }


        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteUser(string id)
        {
            if (_userData.GetUser(id) == null)
            {
                return NotFound($"User with Id of {id} does not exist");
            }
            _userData.DeleteUser(id);
            return Ok();
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditUser(string id, User user)
        {
            User existingUser = _userData.GetUser(id);

            if (existingUser == null)
            {
                return NotFound($"User with Id of {user.UserId} does not exist");
            }

            user.UserId = existingUser.UserId;
            _userData.EditUser(user);
            return Ok("successfully updated user profile.");
        }
    }
}
