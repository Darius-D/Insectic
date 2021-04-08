using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insectic.Models
{
    public class TicketJsonModel
    {
        public int TicketId { get; set; }

        public string? Category { get; set; }

        public string? Priority { get; set; }

        public string? Status { get; set; }

        public DateTime IncidentDate { get; set; }


        public DateTime? DueDate { get; set; }


        public string? TicketDescription { get; set; }

        public string? UserId { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
