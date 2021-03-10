using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;

namespace Insectic.Models
{
    
    public class TicketForm
    {
        public static int count = 0;

        public int TicketId { get; set; }
        public int Category { get; set; }

        public int Priority { get; set; }

        public int Status { get; set; }

        public DateTime IncidentDate { get; set; }
        public DateTime?  DueDate { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string TicketDescription { get; set; }

        public TicketForm()
        {
            count++;
            TicketId = count;
        }
    }
}
