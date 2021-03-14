using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insectic.Models
{
    public class CommentRepository
    {
        private static List<Comment> comments = new List<Comment>();

        public static IEnumerable<Comment> Comments => comments;

        public static void AddUser(Comment comment)
        {
            comments.Add(comment);
        }
    }
}
