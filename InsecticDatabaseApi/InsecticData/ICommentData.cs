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
        List<Comment> GetAllComments();

        List<Comment> GetAllCommentsForTicket(int id);

        public List<Comment> GetUserComments(string userId);

        Comment GetComment(Guid id);

        void AddComment(Guid ticketId, Comment comment);

        void DeleteComment(Guid commentId);

        void EditComment(Comment comment);
    }
}
