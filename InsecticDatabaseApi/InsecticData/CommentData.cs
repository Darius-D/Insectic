using System;
using System.Collections.Generic;
using System.Linq;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public class CommentData : ICommentData
    {


        private readonly InsecticContext _insecticContext;

        public CommentData(InsecticContext insecticContext)
        {
            _insecticContext = insecticContext;
        }


        public List<Comment> GetAllComments()
        {
            return _insecticContext.TicketComments.ToList();
        }


        public List<Comment> GetAllCommentsForTicket(int id)
        {
            List<Comment> ticketComments = new List<Comment>();

            foreach (var ticket in _insecticContext.TicketComments)
            {
                if (ticket.TicketId == id)
                {
                    ticketComments.Add(ticket);
                }
            }

            return ticketComments;
        }


        public Comment GetComment(int id)
        {
            return _insecticContext.TicketComments.Find(id);
        }

        public List<Comment> GetUserComments(string userId)
        {
            var userComments = GetAllComments().Where(c => c.UserId == userId).ToList();
            return userComments;
        }


        public void AddComment(int ticketId, Comment comment)
        {

            comment.CommentDate = DateTime.Now;
            _insecticContext.TicketComments.Add(comment);
            _insecticContext.SaveChanges();
        }


        public void DeleteComment(int commentId)
        {
            var existingComment = _insecticContext.TicketComments.Find(commentId);

            if (existingComment != null)
            {
                _insecticContext.Remove(existingComment);
                _insecticContext.SaveChanges();
                
            }
            
        }


        public void EditComment(Comment comment)
        {
            var existingComment = _insecticContext.TicketComments.Find(comment.CommentId);

            if (existingComment != null)
            {
                
                existingComment.TicketId = comment.TicketId;
                existingComment.CommentId = comment.CommentId;
                existingComment.UserId = comment.UserId;
                existingComment.UserComment = comment.UserComment;
                _insecticContext.TicketComments.Update(existingComment);
                _insecticContext.SaveChanges();
            }
        }
    }
}
