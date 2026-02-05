using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Models;

namespace SimpleWebApi.Data
{
    public class ApiDbContext :DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    EmployeeName = "Alice",
                    EmployeeId = "1001",
                    Department = 1,
                    DateOfBirth = new DateOnly(1990, 1, 20),
                    Gender = "Female",
                    JoiningDate = new DateOnly(2024, 6, 20),
                    Phone = "953678982",
                    Active = true
                },
            new Employee
            {
                Id = 2,
                EmployeeName = "John",
                EmployeeId = "1002",
                Department = 2,
                DateOfBirth = new DateOnly(1999, 3, 11),
                Gender = "Male",
                JoiningDate = new DateOnly(2020, 7, 22),
                Phone = "784778993",
                Active = true
            },
            new Employee
            {
                Id = 3,
                EmployeeName = "Molly",
                EmployeeId = "1003",
                Department = 1,
                DateOfBirth = new DateOnly(2000, 5, 20),
                Gender = "Female",
                JoiningDate = new DateOnly(2026, 6, 20),
                Phone = "34333",
                Active = true
            });
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
