using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;

namespace InsecticDatabaseApi.Models
{
    public class Ticket
    {
        
        [Key]
        public Guid TicketId { get; set; }
        
        public string Category { get; set; }
        
        public string Priority { get; set; }
        
        public string Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime IncidentDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DueDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string TicketDescription { get; set; }

        public string UserId { get; set; } 
        
       
        
    }
}
