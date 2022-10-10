using HrSystem.DataAccess.Models;
using HrSystem.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeePhoneNumber> EmployeePhoneNumber { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EmployeePhoneNumber>().HasKey(table => new
            {
                table.PhoneNumber,
                table.EmployeeId
            });

        }
    }
}
