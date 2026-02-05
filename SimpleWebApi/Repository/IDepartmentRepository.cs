using SimpleWebApi.Models;

namespace SimpleWebApi.Repository
{
    public interface IDepartmentRepository
    {
        public List<Department> GetDepartment();
        public Department? GetDepartmentById(int id);
        public Department AddDepartment(Department dept);
        public bool UpdateDepartment(int id, Department dept);
        public bool DeleteDepartment(int id);
    }
}
