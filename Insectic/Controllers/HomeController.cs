using Insectic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Insectic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Name = "Darius";
            ViewBag.Image = "https://source.unsplash.com/random";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public ViewResult CreateTicket()
        {
            ViewBag.Image = "https://source.unsplash.com/random";
            return View();
        }
        [HttpPost]
        public ViewResult CreateTicket(TicketForm ticket)
        {
            ViewBag.Image = "https://source.unsplash.com/random";
            Repository.AddTicket(ticket);
            return View("Index",ticket);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
