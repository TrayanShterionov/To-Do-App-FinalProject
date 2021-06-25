using Microsoft.EntityFrameworkCore;

namespace ToDoAppM.Data.Context
{
    public class ToDoListContext : DbContext
    {
        public DbSet<ToDoLists> ToDoLists { get; set; }

        public ToDoListContext()
        {
            Database.EnsureCreated();
        }
        public ToDoListContext(DbContextOptions<ToDoAppM.UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB.;Database=ToDoManagement");
        }
    }
}
