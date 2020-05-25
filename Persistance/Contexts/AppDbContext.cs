using Microsoft.EntityFrameworkCore;
using MyTrello.Domain.Models;

namespace MyTrello.Persistance.Contexts
{
    public class AppDbContext : DbContext
    {
        //public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Task>()
            //     .Property(e => e.Task_Priority)
            //     .IsUnicode(false);

            // modelBuilder.Entity<Task>()
            //     .Property(e => e.Task_Name)
            //     .IsUnicode(false);

            // modelBuilder.Entity<Task>()
            //     .Property(e => e.Task_Description)
            //     .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.User_FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.User_LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.User_PhotoPath)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.User_Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.User_Password)
                .IsUnicode(false);
        }
    }
}