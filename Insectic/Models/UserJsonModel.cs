using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Insectic.Models
{
    public class UserJsonModel :IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ResourceGroup { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Supervisor { get; set; }
        public string? Department { get; set; }
    }
}
