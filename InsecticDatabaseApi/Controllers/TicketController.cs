using Microsoft.AspNetCore.Mvc;
using InsecticDatabaseApi.InsecticData;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.Controllers
{
    
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketData _ticketData;
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
        public IActionResult GetTicket(int id)
        {
            var ticket = _ticketData.GetTicket(id);
            if (ticket == null)
            {
                return NotFound($"Ticket with Id of {id} does not exist");
            }
            return Ok(_ticketData.GetTicket(id));
        }

        [HttpGet]
        [Route("api/[controller]/ForUser/{userId}")]
        public IActionResult GetTicketByUserId(string userId)
        {
            var ticket = _ticketData.GetUserTickets(userId);
            if (ticket == null)
            {
                return NotFound($"Tickets associated with the User Id of {userId} do not exist");
            }
            return Ok(_ticketData.GetUserTickets(userId));
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
        public IActionResult DeleteTicket(int id)
        {
            if (_ticketData.GetTicket(id) == null)
            {
                return NotFound($"Ticket with Id of {id} does not exist");
            }
            _ticketData.DeleteTicket(id);
            return Ok();
        }


        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditTicket( int id, Ticket ticket)
        {
            Ticket existingTicket = _ticketData.GetTicket(id);

            if (existingTicket == null)
            {
                return NotFound($"Ticket with Id of {ticket.TicketId} does not exist");
            }

            ticket.TicketId = existingTicket.TicketId;
            _ticketData.EditTicket(ticket);
            return Ok();
        }
    }
}
