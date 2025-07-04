using Crud_in_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Crud_in_API.DTO.DepartmentDto
{
    public class CreateDepartmentDTO
    {
        public int Id { get; set; }
        [MinLength(5)]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        
    }
}
