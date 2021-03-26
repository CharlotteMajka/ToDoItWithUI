using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class TodoContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Assignee> Assignees { get; set; }

        public TodoContext()
        { }

        public TodoContext(DbContextOptions<TodoContext> config) : base(config)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasKey(e => e.Id);
            modelBuilder.Entity<Task>().HasOne(t => t.Assignee);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
    }
}