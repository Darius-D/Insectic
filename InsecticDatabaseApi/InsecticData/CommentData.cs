using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public class CommentData : ICommentData
    {
        private InsecticContext _insecticContext;
        public CommentData(InsecticContext insecticContext)
        {
            _insecticContext = insecticContext;
        }


        /// <summary>
        /// Will return all comments in the database
        /// </summary>
        /// <returns>a List of type TicketComment</returns>
        public List<TicketComment> GetAllComments()
        {
            return _insecticContext.TicketComments.ToList();
        }



        /// <summary>
        /// Returns all comments associated with a desired ticket. 
        /// </summary>
        /// <param name="id">requires the TicketId of the ticket in question.</param>
        /// <returns>a List of type TicketComment</returns>
        public List<TicketComment> GetAllCommentsForTicket(Guid id)
        {
            List<TicketComment> ticketComments = new List<TicketComment>();

            foreach (var ticket in _insecticContext.TicketComments)
            {
                if (ticket.TicketId == id)
                {
                    ticketComments.Add(ticket);
                }
            }

            return ticketComments;
        }



        /// <summary>
        /// Returns a single comment by Guid
        /// </summary>
        /// <param name="id">Requires specific comment id</param>
        /// <returns>a single TicketComment object</returns>
        public TicketComment GetComment(Guid id)
        {
            return _insecticContext.TicketComments.Find(id);
        }



        /// <summary>
        /// Adds a comment to the desired ticket and saves it in the DB. 
        /// </summary>
        /// <param name="comment"> Takes in the newly created ticket</param>
        /// <param name="ticket"> Takes in the ticket comment is associated with</param>
        public void AddComment(TicketComment comment, Ticket ticket)
        {
            comment.CommentId = Guid.NewGuid();
            comment.TicketId = ticket.TicketId;
            _insecticContext.TicketComments.Add(comment);
            _insecticContext.SaveChanges();
        }




        public void DeleteComment(TicketComment comment)
        {
            throw new NotImplementedException();
        }




        public TicketComment EditComment(TicketComment comment)
        {
            throw new NotImplementedException();
        }
    }
}
