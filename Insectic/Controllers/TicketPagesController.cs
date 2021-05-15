using System.Linq;
using System.Threading.Tasks;
using Insectic.BLL;
using Insectic.InsecticData;
using Insectic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Insectic.Controllers
{
    public class TicketPagesController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly UserManager<IdentityUserModel> _userManager;
        
        public TicketPagesController(ITicketRepository repository, UserManager<IdentityUserModel> userManager)
        {
            _ticketRepository = repository;
            _userManager = userManager;
        }

        

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }


        [HttpPost]
        public IActionResult Create(TicketJsonModel ticket)
        {
            
            _ticketRepository.NewTicket(ticket);

            return  RedirectToAction("Dashboard", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var TicketList = await _ticketRepository.GetAllTicketsAsync();

            //foreach (var ticket in TicketList)
            //{
            //    var user = UserApiRepository.GetUser(ticket.UserId);
            //    ticket.UserId = user.FirstName + user.LastName;
            //}
            
            return View(TicketList);
        }

        [HttpPost]
        public IActionResult Filter(string sortBy)
        {
            var tickets = TicketLogic.FilterCollection(sortBy);
            return View("Index", tickets);
        }

        [HttpGet]
        [Route("ticketPages/EditTicket/{ticketId}")]
        public async Task<IActionResult> EditTicket(int ticketId)
        {
            var ticket = await _ticketRepository.GetTicket(ticketId);
            return View(ticket);
        }

        [HttpPost]
        public IActionResult EditTicket(TicketJsonModel ticket)
        {
            _ticketRepository.EditTicket(ticket);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("ticketPages/View/{ticketId}")]
        public async Task<IActionResult> View(int ticketId)
        {
            var ticket = await _ticketRepository.GetTicket(ticketId);
            return View(ticket);
        }
    }
}