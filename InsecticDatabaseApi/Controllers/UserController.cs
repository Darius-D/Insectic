using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsecticDatabaseApi.InsecticData;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserData _userData;

        public UserController(IUserData user)
        {
            _userData = user;
        }

        /// <summary>
        /// Returns all users in the Db.
        /// </summary>
        /// <returns>List of type User</returns>
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllTickets()
        {
            return Ok(_userData.GetAllUsers());
        }


        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _userData.GetUser(id);
            if (user != null)
            {
                return Ok(_userData.GetUser(id));
            }

            return NotFound($"User with Id of {id} does not exist");

        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddUser(User newUser)
        {
            _userData.AddUser(newUser);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + newUser.UserId, newUser);

        }


        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteTicket(string id)
        {
            if (_userData.GetUser(id) != null)
            {
                _userData.DeleteUser(id);
                return Ok();
            }

            return NotFound($"User with Id of {id} does not exist");

        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditTicket(string id, User user)
        {
            User existingUser = _userData.GetUser(id);

            if (existingUser != null)
            {
                user.UserId = existingUser.UserId;
                _userData.EditUser(user);
                return Ok();
            }

            return NotFound($"User with Id of {user.UserId} does not exist");
        }
    }
}
