﻿using System;
using System.Collections.Generic;

namespace InsecticDatabaseApi.Models
{
    public class Ticket
    {
        
        public int TicketId { get; set; }
        
        public string Category { get; set; }
        
        public string Priority { get; set; }
        
        public string Status { get; set; }

        public DateTime IncidentDate { get; set; }

        public DateTime? DueDate { get; set; }

        public string TicketDescription { get; set; }

        public string UserId { get; set; }

        public string AssignedUser { get; set; }

    }
}
