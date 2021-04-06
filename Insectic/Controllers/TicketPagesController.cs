using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insectic.Models;
using Microsoft.Extensions.Logging;

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
        public IActionResult CreateTicket(TicketForm ticket)
        {
           
            ViewBag.Image = "https://source.unsplash.com/random";
            TicketRepository.AddTicket(ticket);

            return RedirectToAction("Index","Home");
        }
    }
}
