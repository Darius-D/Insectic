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
        public ViewResult AddressBook()
        {
            var test = new User("1234", "null")
            {
                ProfilePicture = "https://source.unsplash.com/random",
                FirstName = "Darius",
                LastName = "Dubose",
                Email = "dariusdubose1@gmail.com",

            };
            return View("AddressBook", test);
        }
    }
}
