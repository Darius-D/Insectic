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
        private readonly INoteRepository _noteRepository;
        private UserManager<IdentityUserModel> _userManager;
        public HomeController(ILogger<HomeController> logger, ITicketRepository repository, UserManager<IdentityUserModel> userManager, INoteRepository noteRepository)
        {
            _logger = logger;
            _ticketRepository = repository;
            _userManager = userManager;
            _noteRepository = noteRepository;

        }

        public async Task<IActionResult> Dashboard()
        {
            var currentUser = User.FindFirstValue(ClaimTypes.Name);
            var notes = await _noteRepository.GetAllNotesAsync();
            var t  = notes/*.Where(n => n.UserId.Equals(currentUser))*/;
            ViewBag.Notes = t;

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

        [HttpPost]
        public async Task<IActionResult> AddNote(Note note)
        {
            await _noteRepository.NewNoteAsync(note);
            return RedirectToAction("Dashboard");
        }

        
        public async Task<IActionResult> DeleteNote(int noteId)
        {
             _noteRepository.DeleteNoteAsync(noteId);
            return RedirectToAction("Dashboard");
        }
    }
}
