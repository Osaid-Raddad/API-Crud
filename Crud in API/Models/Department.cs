namespace Crud_in_API.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
