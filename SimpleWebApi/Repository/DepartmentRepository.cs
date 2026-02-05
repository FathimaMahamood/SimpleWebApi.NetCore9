using SimpleWebApi.Models;

namespace SimpleWebApi.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        static private List<Department> _departments;
        public DepartmentRepository()
        {
            _departments = new List<Department>()
            {
                new Department{ Id = 1, Code = "HR", Name = "Human Resource" },
                new Department{ Id = 2, Code = "FIN", Name = "Finance" },
                new Department{ Id = 3, Code = "ENG", Name = "Engineering" },
                new Department{ Id = 4, Code = "IT", Name = "Information Technology" },
                new Department{ Id = 5, Code = "MKT", Name = "Marketing" },
                new Department{ Id = 6, Code = "OPS", Name = "Operations" },
                new Department{ Id = 7, Code = "ADMIN", Name = "Administration" }
            };
        }
        public List<Department> GetDepartment()
        {
            return _departments;
        }
        public Department? GetDepartmentById(int id)
        {
            return _departments.FirstOrDefault(x => x.Id == id);
        }
        public Department AddDepartment(Department dept)
        {
            _departments.Add(dept);
            return dept;
        }
        public bool UpdateDepartment(int id, Department dept)
        {
            var deptObj = _departments.FirstOrDefault(x => x.Id == id);
            if (deptObj != null)
            {
                deptObj.Code = dept.Code;
                deptObj.Name = dept.Name;
                return true;
            }
            return false;
        }
        public bool DeleteDepartment(int id)
        {
            var deptObj = _departments.FirstOrDefault(x => x.Id == id);
            if (deptObj != null)
            {
                _departments.Remove(deptObj);
                return true;
            }
            return false;
        }
    }
}
