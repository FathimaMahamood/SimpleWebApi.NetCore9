using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Common;
using SimpleWebApi.Models;
using System.Linq.Dynamic.Core;

namespace SimpleWebApi.Services
{
    public interface IEmployeeService
    {
        public Task<PagedResponse<Employee>> GetAllAsync( int page, int pageSize,string? sortBy , string? orderBy);
        public Task<Employee?> GetByIdAsync(string id);
        public Task<Employee> AddEmployeeAsync(Employee employee);
        public Task<bool> UpdateEmployeeAsync(string id, Employee employee);
        public Task<bool> DeleteEmployeeAsync(string id);
    }
}
