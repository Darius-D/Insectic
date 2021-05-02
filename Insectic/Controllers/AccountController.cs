using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Insectic.Models;
using Insectic.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Insectic.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUserModel> UserMgr { get; }
        private SignInManager<IdentityUserModel> SignInMgr { get; }
        public AccountController(UserManager<IdentityUserModel> userManager,
            SignInManager<IdentityUserModel> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUserModel()
                {
                    FirstName = userModel.FirstName, LastName = userModel.LastName, 
                    ContactNumber = userModel.ContactNumber, UserName = userModel.FirstName[0] + userModel.LastName, Email = userModel.Email 
                };
                var result = await UserMgr.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    await SignInMgr.SignOutAsync();
                    if ((await SignInMgr.PasswordSignInAsync(user.UserName, userModel.Password, false, false))
                        .Succeeded)
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }
                }
                else
                {  
                    return View();
                }
                 
            }

            return View();
        }
        public async Task<IActionResult> Login()
        {
            var result = await SignInMgr.PasswordSignInAsync("TestUserName", "Test123!", false, false);
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
        
        //public async Task<IActionResult> Register()
        //{
        //    try
        //    {
        //        ViewBag.Message = "User already registered";

        //        IdentityUserModel user = await UserMgr.FindByNameAsync("TestUsers");
        //        if (user == null)
        //        {
        //            user = new IdentityUserModel();
        //            user.UserName = "TestUser";
        //            user.Email = "TestUser @TestUser.com";
        //            user.ContactNumber = "555-123-4567";
        //            user.FirstName = "john";
        //            user.LastName = "Doe";

        //            IdentityResult result = await UserMgr.CreateAsync(user, "Test123!");
        //            ViewBag.Message = "user was created";
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        ViewBag.Message = ex.Message;
        //    }

        //    return View();
        //}

    }
}
