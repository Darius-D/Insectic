using System.Threading.Tasks;
using Insectic.BLL;
using Insectic.InsecticData;
using Insectic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insectic.Controllers
{
    public class TicketPagesController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        
        public TicketPagesController(ITicketRepository repository)
        {
            _ticketRepository = repository;
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
            return View(await _ticketRepository.GetAllTicketsAsync()!);
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
            _ticketRepository.EditTicket(ticket.TicketId,ticket);
            return RedirectToAction("Dashboard", "Home");
        }
    }
}