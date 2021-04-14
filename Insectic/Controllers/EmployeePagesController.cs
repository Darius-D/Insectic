using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insectic.Models;

namespace Insectic.Controllers
{
    public class EmployeePagesController : Controller
    {
        [HttpGet]
        public ViewResult Contacts()
        {
          
            return View("Contacts");
        }
    }
}
