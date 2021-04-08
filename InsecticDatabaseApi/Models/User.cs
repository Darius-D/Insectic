using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace InsecticDatabaseApi.Models
{
    public class User
    {
        

        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public string UserPassword { get; set; }

        public string ResourceGroup { get; set; }

        public string UserRoles { get; set; }

        public string ProfilePicture { get; set; }

        public List<Ticket> Tickets { get; set; }

        



    }
}
