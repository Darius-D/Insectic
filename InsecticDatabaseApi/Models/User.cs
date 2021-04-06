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
        
        private string _userPassword;

        [Key]
        public string UserId { get; set; }

        [MaxLength(30, ErrorMessage = "Name is more than 30 characters")]
        public string FirstName { get; set; }

        [MaxLength(30, ErrorMessage = "Name is more than 30 characters")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string UserPassword { set => this._userPassword = value; }

        [AllowNull]
        public string ResourceGroup { get; set; }

        [AllowNull]
        public int UserRoles { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ProfilePicture { get; set; }

        public List<Ticket> Tickets { get; set; }

        public List<TicketComment> comments { get; set; }



    }
}
