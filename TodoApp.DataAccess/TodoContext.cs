using Microsoft.EntityFrameworkCore;
using TodoApp.DataAccess.Configurations;
using TodoApp.Domain.Entities;

namespace TodoApp.DataAccess
{
    public class TodoContext: DbContext, ITodoContext
    {
        public TodoContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
