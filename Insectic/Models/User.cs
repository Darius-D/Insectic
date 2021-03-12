using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insectic.Models
{
    public class User
    {
        public string UserId { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public string UserPassword { get; private set; }

        public string? ResourceGroup{ get; set; }

        public int UserRoles { get; set; }

        public string ProfilePicture { get; set; }

        public User(string password, string resourceGroup)
        {
            ResourceGroup = resourceGroup;
            UserPassword = password;
        }
    }
}
