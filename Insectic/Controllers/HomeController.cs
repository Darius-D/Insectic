using Insectic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Dynamic;
using System.Threading.Tasks;
using Insectic.BLL;
using Insectic.InsecticData;


namespace Insectic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITicketRepository _ticketRepository;
        public HomeController(ILogger<HomeController> logger, ITicketRepository repository)
        {
            _logger = logger;
            _ticketRepository = repository;
        }

        public async Task<IActionResult> Dashboard()
        {
            
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
