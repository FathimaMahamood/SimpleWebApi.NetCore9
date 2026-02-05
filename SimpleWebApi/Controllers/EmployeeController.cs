using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Common;
using SimpleWebApi.Models;
using SimpleWebApi.Services;
using System.Linq.Dynamic.Core;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SimpleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }
        [HttpGet]
        public async Task<ActionResult<PagedResponse<Employee>>> GetEmployees( [FromQuery] int page = 1,[FromQuery] int pageSize = 10, [FromQuery] string? sortBy = null,[FromQuery] string? orderBy = null)
        {
            var result = await _employeeService.GetAllAsync(page, pageSize, sortBy, orderBy);
            Response.Headers["X-Total-Count"] = result.TotalRecords.ToString();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            //var employee=_employeeRepository.GetById(id);
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            if (employee == null)
                return BadRequest();

            await _employeeService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(AddEmployee), new { id = employee.EmployeeId }, employee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(string id, Employee employee)
        {
            if (await _employeeService.UpdateEmployeeAsync(id, employee))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            if (await _employeeService.DeleteEmployeeAsync(id))
                return NoContent();
            else
                return NotFound();
        }

        [HttpHead("{id}")]
        public async Task<IActionResult> HeadEmployee(string id)
        {
            var exist = await _employeeService.GetByIdAsync(id);
            if(exist == null)
                return NotFound();
            Response.Headers["x-Resource-Exist"] = "true";
            return Ok();
        }
    }
}
