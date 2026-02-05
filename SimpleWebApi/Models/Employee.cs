namespace SimpleWebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; } = null!;
        public string EmployeeName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int Department { get; set; }
        public DateOnly JoiningDate { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
    }
}
