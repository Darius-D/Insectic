using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insectic.Controllers
{
    public class TicketsController : Controller
    {
        [HttpGet]
        public IActionResult CreateTicket()
        {
            return View("CreateTicket");
        }
    }
}
