using System.Threading.Tasks;
using Insectic.BLL;
using Insectic.InsecticData;
using Insectic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insectic.Controllers
{
    public class TicketPagesController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Image = "https://source.unsplash.com/random";
            return View();
        }


        [HttpPost]
        public IActionResult CreateTicket(TicketJsonModel ticket)
        {
            //Local machine storage
            //TicketRepository.AddTicket(ticket);

            ViewBag.Image = "https://source.unsplash.com/random";
            TicketApiRepository.NewTicket(ticket);

            return RedirectToAction("Dashboard", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View( TicketApiRepository.GetAllTickets());
        }

        [HttpPost]
        public IActionResult Filter(string sortBy)
        {
            var tickets = TicketLogic.FilterCollection(sortBy);
            return View("Index", tickets);
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //}
    }
}