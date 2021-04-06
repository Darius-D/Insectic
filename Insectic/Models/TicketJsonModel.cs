using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insectic.Models
{
    public class TicketJsonModel
    {
        public string TicketId { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime IncidentDate { get; set; }
        public object DueDate { get; set; }
        public object PhoneNumber { get; set; }
        public string Email { get; set; }
        public object TicketDescription { get; set; }
    }
}
