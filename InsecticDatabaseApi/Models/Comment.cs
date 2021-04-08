using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace InsecticDatabaseApi.Models
{
    public class Comment
    {

        public int CommentId { get; set; }
       
        public int TicketId { get; set; }

        public string UserId { get; set; }

        public DateTime CommentDate { get; set; }
        
        public string UserComment { get; set; }

    }

}
