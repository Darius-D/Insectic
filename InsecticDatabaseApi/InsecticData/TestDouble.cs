using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public class TestDouble :ITicketData
    {
        public List<Ticket> GetAllTickets()
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicket(Guid id)
        {
            throw new NotImplementedException();
        }

        public void AddTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void DeleteTicket(Guid ticketId)
        {
            throw new NotImplementedException();
        }

        public void EditTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
