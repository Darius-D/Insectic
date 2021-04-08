using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Insectic.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int TicketId { get; set; }

        public string? UserId { get; set; }

        public DateTime CommentDate { get; set; }

        public string? UserComment { get; set; }
    }
}
