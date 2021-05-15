using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insectic.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string NoteBody { get; set; }
        
    }
}
