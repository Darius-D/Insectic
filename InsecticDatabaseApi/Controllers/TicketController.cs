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
    
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketData _ticketData;
        public TicketController(ITicketData ticket)
        {
            _ticketData = ticket;
        }

        /// <summary>
        /// Returns all tickets in the Db.
        /// </summary>
        /// <returns>List of type Ticket</returns>
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllTickets()
        {
            return Ok(_ticketData.GetAllTickets());
        }

        /// <summary>
        /// Returns a single ticket by ticket Id.
        /// </summary>
        /// <param name="id">Guid of the ticket wanting to pull</param>
        /// <returns>a single Ticket object</returns>
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetTicket(Guid id)
        {
            var ticket = _ticketData.GetTicket(id);
            if (ticket != null)
            {
                return Ok(_ticketData.GetTicket(id));
            }

            return NotFound($"Ticket with Guid of {id} does not exist");
        }



        /// <summary>
        /// Adds a ticket object to the Db
        /// </summary>
        /// <param name="newTicket">requires a ticket object. ticket Guid will be auto generated.</param>
        /// <returns>the location in the header. Might remove this. </returns>
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddTicket(Ticket newTicket)
        {
            _ticketData.AddTicket(newTicket);
            //return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + newTicket.TicketId, newTicket);
            return Ok();
        }



        /// <summary>
        /// Removes the ticket from the Db. For Admins only.
        /// </summary>
        /// <param name="id">Requires the ticket Guid id of the ticket you want to delete</param>
        /// <returns>status 202 Ok or NotFound object result</returns>
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteTicket(Guid id)
        {
            if (_ticketData.GetTicket(id) != null)
            {
                _ticketData.DeleteTicket(id);
                return Ok();
            }

            return NotFound($"Ticket with Guid of {id} does not exist");

        }



        /// <summary>
        /// Edits an existing ticket. 
        /// </summary>
        /// <param name="id">the Guid of the ticket you want to edit.</param>
        /// <param name="ticket">Json body as Ticket object</param>
        /// <returns>void</returns>
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditTicket( Guid id, Ticket ticket)
        {
            Ticket existingTicket = _ticketData.GetTicket(id);

            if (existingTicket != null)
            {
                ticket.TicketId = existingTicket.TicketId;
                _ticketData.EditTicket(ticket);
                return Ok();
            }

            return NotFound($"Ticket with Guid of {ticket.TicketId} does not exist");
        }


    }
}
