using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InsecticDatabaseApi.Models  
{
    public class InsecticContext : DbContext
    {
        public InsecticContext(DbContextOptions<InsecticContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }
        public DbSet<User> UsersList { get; set; }
    }
}
