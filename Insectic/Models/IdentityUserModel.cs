using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Insectic.Models
{
    public class IdentityUserModel : IdentityUser<int>
    {

        
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string? ResourceGroup { get; set; }
       public string? ProfilePicture { get; set; }
       public string? Supervisor { get; set; }
       public string? Department { get; set; }


    }
}
