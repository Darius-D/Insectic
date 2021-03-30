using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public interface ICommentData
    {
        List<TicketComment> GetAllComments();

        List<TicketComment> GetAllCommentsForTicket(Guid id);

        TicketComment GetComment(Guid id);

        void AddComment(TicketComment comment, Ticket ticket);

        void DeleteComment(TicketComment comment);

        TicketComment EditComment(TicketComment comment);
    }
}
