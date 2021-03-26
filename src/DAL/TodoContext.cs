using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class TodoContext : DbContext
    {
        public DbSet<Task> Task { get; set; }
        public DbSet<Assignee> Assignee { get; set; }

        public TodoContext()
        { }

        public TodoContext(DbContextOptions<TodoContext> config) : base(config)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
    }
}