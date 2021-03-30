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

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllTickets()
        {
            return Ok(_ticketData.GetAllTickets());
        }

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

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddTicket(Ticket newTicket)
        {
            _ticketData.AddTicket(newTicket);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + newTicket.TicketId, newTicket);

        }

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

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditTicket( Guid id, Ticket ticket)
        {
            var existingTicket = _ticketData.GetTicket(id);

            if (existingTicket != null)
            {
                existingTicket.TicketId = existingTicket.TicketId;
                _ticketData.EditTicket(ticket);
                return Ok();
            }

            return NotFound($"Ticket with Guid of {ticket.TicketId} does not exist");
        }


    }
}
