using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Models;

namespace To_Do_List_API.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.ToDoItems)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
        }           

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
