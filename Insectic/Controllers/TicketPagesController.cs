using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insectic.InsecticData;
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

        //Todo This works however the dates still don't go into the DB correctly. 
        [HttpPost]
        public IActionResult CreateTicket( TicketJsonModel ticket)
        {
            //Local machine storage
            //TicketRepository.AddTicket(ticket);

            ViewBag.Image = "https://source.unsplash.com/random";
            TicketApiRepository.NewTicket(ticket);

            return RedirectToAction("Index","Home");
        }
    }
}
