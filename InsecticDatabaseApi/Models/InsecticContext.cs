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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();
            var ticket = modelBuilder.Entity<Ticket>();
            var comment = modelBuilder.Entity<Comment>();

            user.ToTable("Users");
            user.Property(p => p.UserId).IsRequired().HasMaxLength(25);
            user.Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            user.Property(p => p.LastName).HasMaxLength(30).IsRequired();
            user.Property(p => p.Email).IsRequired();
            user.Property(p => p.ContactNumber).HasMaxLength(15).HasColumnName("PhoneNumber").IsRequired();
            user.Property(p => p.UserPassword).IsRequired();
            user.Property(p => p.UserRoles).IsRequired();
            user.Property(p => p.ResourceGroup).HasMaxLength(50);
            

            
            ticket.Property(p => p.TicketId).ValueGeneratedOnAdd();
            ticket.Property(p => p.Category).IsRequired().HasColumnName("TicketCategory");
            ticket.Property(p => p.Status).IsRequired().HasMaxLength(30);
            ticket.Property(p => p.IncidentDate).HasColumnType("datetime2").HasPrecision(0);
            ticket.Property(p => p.DueDate).HasColumnType("datetime2").HasPrecision(0);
            ticket.Property(p => p.TicketDescription).IsRequired();
            ticket.Property(p => p.Priority).IsRequired().HasMaxLength(20);
            ticket.Property(p => p.UserId).IsRequired();

            
            comment.Property(p => p.CommentId).ValueGeneratedOnAdd();
            comment.Property(p => p.UserComment).IsRequired();
            comment.Property(p => p.CommentDate).IsRequired().HasColumnType("datetime2").HasPrecision(0);
            comment.Property(p => p.TicketId).IsRequired();
            comment.Property(p => p.UserId).IsRequired();


        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Comment> TicketComments { get; set; }
        public DbSet<User> UsersList { get; set; }
    }
}
