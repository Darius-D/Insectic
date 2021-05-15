using System;
using System.Collections.Generic;
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
        [Route("api/[controller]/AddUser")]
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
                    return Ok("Successfully Added");
                }
            }

            return BadRequest("Failed to Add User");

        }

        [HttpGet]
        [Route("api/[Controller]/AddAll")]
        public async Task<IActionResult> AddMockUsers()
        {
            var password = "ADmin12!@";
            var userList = new List<User>()
            {

                new User() { FirstName= "	Ashly		",  LastName="	Trendle		", Email="atrendlea@tiny.cc			", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="atrendlea@tiny.cc" , Department = "Sales"},
                new User() { FirstName= "	Bettye		",  LastName="	Paulack		", Email="bpaulackj@ucoz.ru			", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="bpaulackj@ucoz.ru"  , Department = "Cloud"},
                new User() { FirstName= "	Calhoun		",  LastName="	Bolmann		", Email="cbolmann0@over-blog.com		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu"  , UserName="cbolmann0@over-blog.com",Department  = "Operations"},
                new User() { FirstName= "	Currie		",  LastName="	Braunfeld	", Email="cbraunfeld5@jalbum.net		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team C", ProfilePicture=   "https://source.unsplash.com/user/erondu"  , UserName="cbraunfeld5@jalbum.net" , Department = "Human Resources"},
                new User() { FirstName= "	Cordula		",  LastName="	Fordyce		", Email="cfordyceg@diigo.com			", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu"  , UserName="cfordyceg@diigo.com" , Department = "Finances"},
                new User() { FirstName= "	Claudelle	",  LastName="	Lockery		", Email="clockeryc@github.com		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="clockeryc@github.com" , Department = "Legal" },
                new User() { FirstName= "	Dickie		",  LastName="	Cake		", Email="dcake2@ucla.edu				", PhoneNumber= "555-123-4567", ResourceGroup=  "Team C", ProfilePicture=   "https://source.unsplash.com/user/erondu"  , UserName="dcake2@ucla.edu" , Department = "Technology and Research"},
                new User() { FirstName= "	Derrick		",  LastName="	Frizzell	", Email="dfrizzellb@unicef.org		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="dfrizzellb@unicef.org" ,Department  = "Operations" },
                new User() { FirstName= "	Feodora		",  LastName="	Tripon		", Email="ftripond@printfriendly.com	", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu"  , UserName="ftripond@printfriendly.com",Department = "Development"  },
                new User() { FirstName= "	Hiram		",  LastName="	Lohmeyer	", Email="hlohmeyer8@google.ca		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team C", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="ftripond@printfriendly.com" ,Department = "Development" },
                new User() { FirstName= "	Harv		",  LastName="	Sacks		", Email="hsackse@berkeley.edu		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="hsackse@berkeley.edu",Department  = "Operations"  },
                new User() { FirstName= "	Joann		",  LastName="	Fogel		", Email="jfogelf@accuweather.com		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu"  , UserName="jfogelf@accuweather.com",Department  = "Operations"  },
                new User() { FirstName= "	Keriann		",  LastName="	Hofton		", Email="khofton7@digg.com			", PhoneNumber= "555-123-4567", ResourceGroup=  "Team C", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="khofton7@digg.com	"  , Department = "Technology and Research" },
                new User() { FirstName= "	Minerva		",  LastName="	Cracknall	", Email="mcracknall6@woothemes.com	", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="mcracknall6@woothemes.com" , Department = "Technology and Research"  },
                new User() { FirstName= "	Artemis		",  LastName="	Thresh		", Email="athresh4@gmail.com			", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu " , UserName="athresh4@gmail.com", Department = "Development" },
                new User() { FirstName= "	Nora		",  LastName="	Edgecombe	", Email="nedgecombe1@ox.ac.uk		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team C", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="nedgecombe1@ox.ac.uk", Department = "Cloud" },
                new User() { FirstName= "	Rennie		",  LastName="	Mathes		", Email="rmathesi@dagondesign.com	", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="rmathesi@dagondesign.com" , Department = "Cloud" },
                new User() { FirstName= "	Slade		",  LastName="	Throughton	", Email="sthroughton3@oaic.gov.au	", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="sthroughton3@oaic.gov.au"  , Department = "Technology and Research" },
                new User() { FirstName= "	Tandie		",  LastName="	Casterot	", Email="tcasteroth@instagram.com	", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="tcasteroth@instagram.com",Department  = "Operations"  },
                new User() { FirstName= "	Toma		",  LastName="	Feary		", Email="tfeary9@youtu.be		  	", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName=  "tfeary9@youtu.be", Department = "Cloud" }
            };

            foreach (var user in userList)
            {
                user.FirstName.Trim();
                user.LastName.Trim();
                user.Email.Trim();
                user.PhoneNumber.Trim();
                user.ResourceGroup.Trim();
                user.ProfilePicture.Trim();
                user.Department.Trim();

                var result = await UserMgr.CreateAsync(user, password);
                if (result.Succeeded)
                {

                    await SignInMgr.SignOutAsync();
                    if ((await SignInMgr.PasswordSignInAsync(user.UserName, password, false, false))
                        .Succeeded)
                    {
                        Console.WriteLine("yes");
                    }


                }
            }

            return Ok();
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
