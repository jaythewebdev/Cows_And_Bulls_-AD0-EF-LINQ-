using Microsoft.EntityFrameworkCore;
using UsersModelLibrary;

namespace Context
{
    public class UserContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-1J0KOR9F\\SQLSERVER2023JAI;Integrated Security=true;Initial Catalog=dbCowsAndBulls");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<AttemptDetails> AttemptDetails { get; set; }
    }
}