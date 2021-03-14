using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Insectic.Models
{
    public class Comment
    {
        private static int count = 100;
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int TicketId { get; set; }
        public string UserId { get; set; }
        public int CommentId { get; }
        public DateTime CommentDateTime { get; set; }

        public Comment()
        {
            CommentId = count;
            count++;
        }
    }
}
