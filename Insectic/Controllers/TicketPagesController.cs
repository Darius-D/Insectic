using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Insectic.BLL;
using Insectic.InsecticData;
using Insectic.Models;


namespace Insectic.Controllers
{
    public class TicketPagesController : Controller
    {
        
       

        [HttpGet]
        public IActionResult CreateTicket()
        {
            ViewBag.Image = "https://source.unsplash.com/random";
            return View(); 
        }

        
        [HttpPost]
        public IActionResult CreateTicket( TicketJsonModel ticket)
        {
            //Local machine storage
            //TicketRepository.AddTicket(ticket);

            ViewBag.Image = "https://source.unsplash.com/random";
            TicketApiRepository.NewTicket(ticket);

            return RedirectToAction("Index","Home");
        }

       
        [HttpGet]
        public async Task<IActionResult> ViewTickets()
        {
            return  View(TicketApiRepository.GetAllTickets());
        }

        [HttpPost]
        public IActionResult Filter(string sortBy)
        {
            var tickets = TicketLogic.FilterCollection(sortBy);
            return View("ViewTickets", tickets);
        }
    }
}
