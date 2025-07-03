using Crud_in_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_in_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-420PRC7;Database=API_test;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
