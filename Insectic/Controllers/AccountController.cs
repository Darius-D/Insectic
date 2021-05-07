using System;
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
                
                var user = new IdentityUserModel()
                {
                    FirstName = userModel.FirstName, LastName = userModel.LastName, 
                    ContactNumber = userModel.ContactNumber, UserName = userModel.Email, Email = userModel.Email
                };
                var result = await UserMgr.CreateAsync(user, userModel.Password);
                
                if (result.Succeeded)
                {

                    await SignInMgr.SignOutAsync();
                    if ((await SignInMgr.PasswordSignInAsync(user.UserName, userModel.Password, false, false))
                        .Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }
                else
                {  
                    return View();
                }
                 
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
        
    }
}
