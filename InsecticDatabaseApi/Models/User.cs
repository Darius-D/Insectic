using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace InsecticDatabaseApi.Models
{
    public class User : IdentityUser<int>
    {


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ResourceGroup { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Supervisor { get; set; }
        public string? Department { get; set; }


    }
}
