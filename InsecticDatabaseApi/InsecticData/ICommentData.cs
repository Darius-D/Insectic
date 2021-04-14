using System.Collections.Generic;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public interface ICommentData
    {
        List<Comment> GetAllComments();

        List<Comment> GetAllCommentsForTicket(int id);

        public List<Comment> GetUserComments(string userId);

        Comment GetComment(int id);

        void AddComment(int ticketId, Comment comment);

        void DeleteComment(int commentId);

        void EditComment(Comment comment);
    }
}
