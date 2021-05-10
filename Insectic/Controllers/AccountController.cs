using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Insectic.Models;
using Insectic.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Insectic.Controllers
{
    
    public class AccountController : Controller
    {
        private HttpClient Client = new HttpClient();
        private UserManager<IdentityUserModel> UserMgr { get; }
        private SignInManager<IdentityUserModel> SignInMgr { get; }
        public AccountController(UserManager<IdentityUserModel> userManager,
            SignInManager<IdentityUserModel> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;

        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel userModel)
        {
            if (ModelState.IsValid)
            {

                //var user = new IdentityUserModel()
                //{
                //    FirstName = userModel.FirstName,
                //    LastName = userModel.LastName,
                //    PhoneNumber = userModel.ContactNumber,
                //    UserName = userModel.Email,
                //    Email = userModel.Email,
                //    Department = userModel.Department
                //};
                //var result = await UserMgr.CreateAsync(user, userModel.Password);

                //if (result.Succeeded)
                //{

                //    await SignInMgr.SignOutAsync();
                //    if ((await SignInMgr.PasswordSignInAsync(user.UserName, userModel.Password, false, false))
                //        .Succeeded)
                //    {
                //        return RedirectToAction("Login", "Account");
                //    }
                //}
                //else
                //{
                //    return View();
                //}

            }

            return View();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var result = await SignInMgr.PasswordSignInAsync(login.UserName, login.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                ViewBag.Result = "result is" + result.ToString();
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        //To add mock users
        public async Task<IActionResult> AddManyUsers()
        {
            var password = "ADmin12!@";
            var userList = new List<IdentityUserModel>()
            {
                
                new IdentityUserModel() { FirstName= "	Artemis		",  LastName="	Thresh		", Email="athresh4@gmail.com			", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu " , UserName="athresh4@gmail.com", Department = "Development" },
                new IdentityUserModel() { FirstName= "	Ashly		",  LastName="	Trendle		", Email="atrendlea@tiny.cc			", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="atrendlea@tiny.cc" , Department = "Sales"},
                new IdentityUserModel() { FirstName= "	Bettye		",  LastName="	Paulack		", Email="bpaulackj@ucoz.ru			", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="bpaulackj@ucoz.ru"  , Department = "Cloud"},
                new IdentityUserModel() { FirstName= "	Calhoun		",  LastName="	Bolmann		", Email="cbolmann0@over-blog.com		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu"  , UserName="cbolmann0@over-blog.com",Department  = "Operations"},
                new IdentityUserModel() { FirstName= "	Currie		",  LastName="	Braunfeld	", Email="cbraunfeld5@jalbum.net		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team C", ProfilePicture=   "https://source.unsplash.com/user/erondu"  , UserName="cbraunfeld5@jalbum.net" , Department = "Human Resources"},
                new IdentityUserModel() { FirstName= "	Cordula		",  LastName="	Fordyce		", Email="cfordyceg@diigo.com			", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu"  , UserName="cfordyceg@diigo.com" , Department = "Finances"},
                new IdentityUserModel() { FirstName= "	Claudelle	",  LastName="	Lockery		", Email="clockeryc@github.com		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="clockeryc@github.com" , Department = "Legal" },
                new IdentityUserModel() { FirstName= "	Dickie		",  LastName="	Cake		", Email="dcake2@ucla.edu				", PhoneNumber= "555-123-4567", ResourceGroup=  "Team C", ProfilePicture=   "https://source.unsplash.com/user/erondu"  , UserName="dcake2@ucla.edu" , Department = "Technology and Research"},
                new IdentityUserModel() { FirstName= "	Derrick		",  LastName="	Frizzell	", Email="dfrizzellb@unicef.org		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="dfrizzellb@unicef.org" ,Department  = "Operations" },
                new IdentityUserModel() { FirstName= "	Feodora		",  LastName="	Tripon		", Email="ftripond@printfriendly.com	", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu"  , UserName="ftripond@printfriendly.com",Department = "Development"  },
                new IdentityUserModel() { FirstName= "	Hiram		",  LastName="	Lohmeyer	", Email="hlohmeyer8@google.ca		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team C", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="ftripond@printfriendly.com" ,Department = "Development" },
                new IdentityUserModel() { FirstName= "	Harv		",  LastName="	Sacks		", Email="hsackse@berkeley.edu		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="hsackse@berkeley.edu",Department  = "Operations"  },
                new IdentityUserModel() { FirstName= "	Joann		",  LastName="	Fogel		", Email="jfogelf@accuweather.com		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu"  , UserName="jfogelf@accuweather.com",Department  = "Operations"  },
                new IdentityUserModel() { FirstName= "	Keriann		",  LastName="	Hofton		", Email="khofton7@digg.com			", PhoneNumber= "555-123-4567", ResourceGroup=  "Team C", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="khofton7@digg.com	"  , Department = "Technology and Research" },
                new IdentityUserModel() { FirstName= "	Minerva		",  LastName="	Cracknall	", Email="mcracknall6@woothemes.com	", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="mcracknall6@woothemes.com" , Department = "Technology and Research"  },
                new IdentityUserModel() { FirstName= "	Nora		",  LastName="	Edgecombe	", Email="nedgecombe1@ox.ac.uk		", PhoneNumber= "555-123-4567", ResourceGroup=  "Team C", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="nedgecombe1@ox.ac.uk", Department = "Cloud" },
                new IdentityUserModel() { FirstName= "	Rennie		",  LastName="	Mathes		", Email="rmathesi@dagondesign.com	", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="rmathesi@dagondesign.com" , Department = "Cloud" },
                new IdentityUserModel() { FirstName= "	Slade		",  LastName="	Throughton	", Email="sthroughton3@oaic.gov.au	", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="sthroughton3@oaic.gov.au"  , Department = "Technology and Research" },
                new IdentityUserModel() { FirstName= "	Tandie		",  LastName="	Casterot	", Email="tcasteroth@instagram.com	", PhoneNumber= "555-123-4567", ResourceGroup=  "Team B", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName="tcasteroth@instagram.com",Department  = "Operations"  },
                new IdentityUserModel() { FirstName= "	Toma		",  LastName="	Feary		", Email="tfeary9@youtu.be		  	", PhoneNumber= "555-123-4567", ResourceGroup=  "Team A", ProfilePicture=   "https://source.unsplash.com/user/erondu	"  , UserName=  "tfeary9@youtu.be", Department = "Cloud" }
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
    }
}
