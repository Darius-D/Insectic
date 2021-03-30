using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsecticDatabaseApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsecticDatabaseApi.InsecticData
{
    public class TicketData : ITicketData
    {
        private InsecticContext _insecticContext;
        public TicketData(InsecticContext insecticContext)
        {
            _insecticContext = insecticContext;
        }


        /// <summary>
        /// Returns all tickets in the Db.
        /// </summary>
        /// <returns>List opf type Ticket</returns>
        public List<Ticket> GetAllTickets()
        {
            return _insecticContext.Tickets.ToList();
        }



        /// <summary>
        /// Returns a single ticket by ticket Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a single Ticket object</returns>
        public Ticket GetTicket(Guid id)
        {
            return _insecticContext.Tickets.Find(id);
        }



        /// <summary>
        /// Adds a ticket object to the Db
        /// </summary>
        /// <param name="ticket">requires a ticket object</param>
        public void AddTicket(Ticket ticket)
        {
            ticket.TicketId = Guid.NewGuid();
            _insecticContext.Tickets.Add(ticket);
            _insecticContext.SaveChanges();
            
        }

        /// <summary>
        /// Removes the ticket from the Db. For Admins only.
        /// </summary>
        /// <param name="ticketId">Requires the ticket Id of the ticket you want to delete</param>
        public void DeleteTicket(Guid ticketId)
        {
            var existingTicket = _insecticContext.Tickets.Find(ticketId);

                _insecticContext.Tickets.Remove(existingTicket);
                _insecticContext.SaveChanges();
            
        }

        public void EditTicket(Ticket ticket)
        {
            
            
                _insecticContext.Tickets.Update(ticket);
                _insecticContext.SaveChanges();
            
        }
    }
}
