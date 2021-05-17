
using System.Threading.Tasks;
using Insectic.InsecticData;
using Microsoft.AspNetCore.Mvc;
using Insectic.Models;
using Insectic.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
                UserApiRepository.AddUser(userModel);
            }

            if (await UserMgr.FindByEmailAsync(userModel.Email) != null)
            {
                return View("Login");
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
