using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Common;
using SimpleWebApi.Data;
using SimpleWebApi.Models;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Tokenizer;

namespace SimpleWebApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApiDbContext _context;
        public EmployeeService(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResponse<Employee>> GetAllAsync( int page, int pageSize,string? sortBy , string? orderBy)
        {
            
            var query = _context.Employees.AsQueryable();
            var totalCount = await query.CountAsync();
            // Default sorting
            sortBy ??= "Id";
            orderBy ??= "asc";

            // Validate property exists (VERY IMPORTANT)
            if (!typeof(Employee).GetProperties()
                .Any(p => p.Name.Equals(sortBy,
                     StringComparison.OrdinalIgnoreCase)))
            {
                sortBy = "Id";
            }
            query = query.OrderBy($"{sortBy} {orderBy}");

            var skip = (page - 1) * pageSize;
            var employees = await query.AsNoTracking().Skip(skip).Take(pageSize).ToListAsync();
            var retObj= new PagedResponse<Employee>
            {
                Data = employees,
                TotalRecords = totalCount,
                Page = page,
                PageSize = pageSize
            };
            return retObj;
        }
        public async Task<Employee?> GetByIdAsync(string id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            return employee;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<bool> UpdateEmployeeAsync(string id, Employee employee)
        {
            var existing = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (existing == null)
                return false;
            existing.EmployeeName = employee.EmployeeName;
            existing.Active = employee.Active;
            existing.Gender = employee.Gender;
            existing.JoiningDate = employee.JoiningDate;
            existing.Phone = employee.Phone;
            existing.Department = employee.Department;
            existing.DateOfBirth = employee.DateOfBirth;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteEmployeeAsync(string id)
        {
            //var existing = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            //if (existing == null)
            //    return false;
            //_context.Employees.Remove(existing);
            //await _context.SaveChangesAsync();
            //return true;

            var rows = await _context.Employees
                         .Where(e => e.EmployeeId == id)
                         .ExecuteDeleteAsync();
            return rows > 0;
        }
    }
}
