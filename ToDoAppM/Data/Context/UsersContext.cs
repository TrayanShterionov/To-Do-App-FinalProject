using Microsoft.EntityFrameworkCore;

namespace ToDoAppM
{
    public class UserContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        
        public UserContext()
        {
            Database.EnsureCreated();
        }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB.;Database=ToDoManagement");
        }
    }
}
