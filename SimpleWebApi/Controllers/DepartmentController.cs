using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Models;
using SimpleWebApi.Repository;

namespace SimpleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _deptRepository;
        public DepartmentController(IDepartmentRepository deptRepository)
        {
            _deptRepository = deptRepository;
        }

        [HttpGet]
        public ActionResult<List<Department>> GetDepartments()
        {

            return Ok(_deptRepository.GetDepartment());
        }
        [HttpGet("{Id}")]
        public ActionResult<Department>GetDepartmentById(int Id)
        {
            var dept=_deptRepository.GetDepartmentById(Id);
            if (dept == null)
                return NotFound();
            return Ok(dept);
        }
        [HttpPost]
        public ActionResult<Department> AddDepartment(Department dept)
        {
            if(dept==null)
                return BadRequest();
            _deptRepository.AddDepartment(dept);
            return CreatedAtAction(nameof(AddDepartment), new { id = dept.Id }, dept);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, Department dept)
        {
            if (_deptRepository.UpdateDepartment(id, dept))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            if(_deptRepository.DeleteDepartment(id))
                return NoContent();
            return NotFound();
        }
    }
}
