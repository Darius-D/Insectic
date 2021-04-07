using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public interface ICommentData
    {
        List<TicketComment> GetAllComments();

        List<TicketComment> GetAllCommentsForTicket(Guid id);

        public List<TicketComment> GetUserComments(string userId);

        TicketComment GetComment(Guid id);

        void AddComment(Guid ticketId, TicketComment comment);

        void DeleteComment(Guid commentId);

        void EditComment(TicketComment comment);
    }
}
