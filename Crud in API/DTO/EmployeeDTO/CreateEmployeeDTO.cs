using System.ComponentModel.DataAnnotations;

namespace Crud_in_API.DTO.EmployeeDTO
{
    public class CreateEmployeeDTO
    {
        public int Id { get; set; }
        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [Range(0, 100000)]
        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }
    }
}
