using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsecticDatabaseApi.InsecticData;
using InsecticDatabaseApi.Models;
using InsecticDatabaseApi.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace InsecticDatabaseApi.Controllers
{
    
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<User> UserMgr { get; }
        private SignInManager<User> SignInMgr { get; }
        private readonly IUserData _userData;

        public UserController(IUserData user, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userData = user;
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

       
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userData.GetAllUsers());
        }


        [HttpGet]
        [Route("api/[controller]/{userName}")]
        public async Task<IActionResult> GetUser(string userName)
        {
            var user = await UserMgr.FindByNameAsync(userName);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound($"User with Id of {userName} does not exist");

        }

        [HttpGet]
        [Route("api/[controller]/ForSupervisor{supervisor}")]
        public IActionResult GetUsersOfSupervisor(string supervisor)
        {
            var user = UserMgr.Users.Where(u => u.Supervisor.Equals(supervisor));

            if (!user.Any())
            {
                return NotFound($"Supervisor with Id of {supervisor} does not exist");
            }
            return Ok(_userData.GetUsersBySupervisor(supervisor));
        }

        [HttpGet]
        [Route("api/[controller]/ForGroup{group}")]
        public IActionResult GetUsersOfResourceGroup(string group)
        {
            return Ok(_userData.GetUserByResourceGroup(group));
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> AddUser(UserViewModel userModel)
        {
            var user = new User()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                PhoneNumber = userModel.ContactNumber,
                UserName = userModel.Email,
                Email = userModel.Email,
                Department = userModel.Department
            };
            var result = await UserMgr.CreateAsync(user, userModel.Password);

            if (result.Succeeded)
            {

                await SignInMgr.SignOutAsync();
                if ((await SignInMgr.PasswordSignInAsync(user.UserName, userModel.Password, false, false))
                    .Succeeded)
                {
                    return Ok("Successfully Deleted");
                }
            }

            return BadRequest("Failed to Add User");

        }


        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (await UserMgr.FindByEmailAsync(id) != null)
            {
               await UserMgr.DeleteAsync(UserMgr.FindByEmailAsync(id).Result);
               return Ok($"Successfully Deleted User with User ID of {id}");
            }

            return BadRequest($"failed to delete User, User with User ID of {id} not found");

        }


        //todo: fix this method
        [HttpPatch]
        [Route("api/[controller]/{userName}")]
        public async Task<IActionResult> EditUser(string userName, User user)
        {

            if ( await UserMgr.FindByNameAsync(userName) != null)
            {
              var results = await UserMgr.UpdateAsync(user);

              if (results.Succeeded)
                  return Ok($"User with user Id of {userName} has been updated.");

              return NotFound($"User with user Name of {userName} does not exist");
            }

            return NotFound($"User with user Name of {userName} does not exist");
        }
    }
}
