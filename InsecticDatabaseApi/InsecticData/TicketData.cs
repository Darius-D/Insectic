using System.Collections.Generic;
using System.Linq;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public class TicketData : ITicketData
    {
        private readonly InsecticContext _insecticContext;

        public TicketData(InsecticContext insecticContext)
        {
            _insecticContext = insecticContext;
        }


        public List<Ticket> GetAllTickets()
        {
            return _insecticContext.Tickets.ToList();
        }

        public Ticket GetTicket(int id)
        {
            return _insecticContext.Tickets.Find(id);
        }


        public List<Ticket> GetUserTickets(string userId)
        {
            var userTickets = GetAllTickets().Where(t => t.UserId == userId).ToList();
            return userTickets;
        }


        public void AddTicket(Ticket ticket)
        {
            _insecticContext.Tickets.Add(ticket);
            _insecticContext.SaveChanges();
        }


        public void DeleteTicket(int ticketId)
        {
            var existingTicket = _insecticContext.Tickets.Find(ticketId);

            _insecticContext.Tickets.Remove(existingTicket);
            _insecticContext.SaveChanges();
        }


        public void EditTicket(Ticket ticket)
        {
            var existingTicket = _insecticContext.Tickets.Find(ticket.TicketId);

            
            
                existingTicket.TicketId = ticket.TicketId;
                existingTicket.TicketDescription = ticket.TicketDescription;
                existingTicket.Category = ticket.Category;
                existingTicket.DueDate = ticket.DueDate;
                existingTicket.AssignedUser = ticket.AssignedUser;
                existingTicket.IncidentDate = ticket.IncidentDate;
                existingTicket.Priority = ticket.Priority;
                existingTicket.Status = ticket.Status;
                existingTicket.UserId = existingTicket.UserId;
                
                _insecticContext.Tickets.Update(existingTicket);
                _insecticContext.SaveChanges();
            
        }
    }
}