using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insectic.Models.ViewModels
{
    public class TicketIndexModel
    {
        public int TicketId { get; set; }
        public string Priority { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime DueDate { get; set; }
        public string SubmittingUser { get; set; }
        public string AssignedUser { get; set; }
    }
}
