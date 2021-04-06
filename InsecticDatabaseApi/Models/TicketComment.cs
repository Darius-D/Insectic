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
        
        public Guid TicketId { get; set; }

        [Required]
        public string UserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CommentDateTime { get; set; }

        public string Comment { get; set; }

         
        
    }

}
