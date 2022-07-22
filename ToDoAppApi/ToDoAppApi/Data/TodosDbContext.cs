using Microsoft.EntityFrameworkCore;
using ToDoAppApi.Configuration;
using ToDoAppApi.Seeders;

namespace ToDoAppApi.Data
{
    public class TodosDbContext : DbContext
    {
        public TodosDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoConfiguration());

            modelBuilder.Seed();
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
