using System;
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

        [HttpGet]
        [Route("api/[controller]/ForGroup{group}")]
        public IActionResult GetUsersOfResourceGroup(string group)
        {
            return Ok(_userData.GetUserByResourceGroup(group));
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task AddUser(UserViewModel userModel)
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
                    Console.WriteLine("yes"); 
                }
            }
            else
            {
                Console.WriteLine("no");
            }
            
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
        public IActionResult EditUser(string userName, User user)
        {
            var existingUser = _userData.GetUser(userName);

            if (existingUser == null)
            {
                return NotFound($"User with user Name of {userName} does not exist");
            }

            user.Id = existingUser.Id;
            _userData.EditUser(user);
            return Ok("successfully updated user profile.");
        }
    }
}
