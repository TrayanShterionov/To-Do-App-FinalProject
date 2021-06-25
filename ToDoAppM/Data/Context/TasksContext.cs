using Microsoft.EntityFrameworkCore;
namespace ToDoAppM.Data.Context
{
    public class TasksContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }

        public TasksContext()
        {
            Database.EnsureCreated();
        }
        public TasksContext(DbContextOptions<ToDoAppM.Data.Context.TasksContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB.;Database=ToDoManagement");
        }
    }
}
