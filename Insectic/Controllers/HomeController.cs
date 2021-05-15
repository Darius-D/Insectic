using Insectic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Insectic.BLL;
using Insectic.InsecticData;
using Microsoft.AspNetCore.Identity;


namespace Insectic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITicketRepository _ticketRepository;
        private UserManager<IdentityUserModel> _userManager;
        public HomeController(ILogger<HomeController> logger, ITicketRepository repository, UserManager<IdentityUserModel> userManager)
        {
            _logger = logger;
            _ticketRepository = repository;
            _userManager = userManager;

        }

        public async Task<IActionResult> Dashboard()
        {
            //ViewBag.currentUser = User.FindFirstValue(ClaimTypes.Name);

            return View(await _ticketRepository.GetAllTicketsAsync()!);
        }
        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
