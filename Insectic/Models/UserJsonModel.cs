using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Insectic.Models
{
    public class UserJsonModel
    {
        public string? UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? ContactNumber { get; set; }

        public string? UserPassword { get; set; }

        public string? ResourceGroup { get; set; }

        public string? UserRoles { get; set; }

        public string? ProfilePicture { get; set; }

        public List<TicketJsonModel>? Tickets { get; set; }
    }
}
