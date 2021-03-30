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
    public class TicketComment
    {

        

        [Key]
        public Guid CommentId { get; set; }

        [ForeignKey("TicketId")]
        public Guid TicketId { get; set; }

        [Required]
        public int UserId { get; set; }

        [DataType(DataType.DateTime)]
        DateTime CommentDateTime { get; }

        [MinLength(3)]
        public string Comment { get; set; }

         TicketComment()
         {
             CommentDateTime = DateTime.Now;
         }
        
    }

}
