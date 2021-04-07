using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public interface ITicketData
    {
        List<Ticket> GetAllTickets();

        Ticket GetTicket(Guid id);

        public List<Ticket> GetUserTickets(string userId);

        void AddTicket(Ticket ticket);

        void DeleteTicket(Guid ticketId);

        void EditTicket(Ticket ticket);
    }
}
