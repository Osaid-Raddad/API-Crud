namespace Crud_in_API.DTO.EmployeeDTO
{
    public class CreateEmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
