using System.Collections.Generic;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public interface ITicketData
    {
        List<Ticket> GetAllTickets();

        Ticket GetTicket(int id);

        public List<Ticket> GetUserTickets(string userId);

        void AddTicket(Ticket ticket);

        void DeleteTicket(int ticketId);

        void EditTicket(Ticket ticket);
    }
}
