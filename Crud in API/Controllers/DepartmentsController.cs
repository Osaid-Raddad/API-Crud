using Crud_in_API.Data;
using Crud_in_API.DTO.DepartmentDto;
using Crud_in_API.DTO;
using Crud_in_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Crud_in_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpGet("")]
        public IActionResult Index()
        {
            var Departments = context.Departments
                .Select(d => new CreateDepartmentDTO
                {
                    Id = d.Id,
                    Name = d.Name, 
                }).ToList();

            return Ok(Departments);
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDTO request)
        {
           
            var department = new Department
            {
                Name = request.Name,
            };

            context.Departments.Add(department);
            context.SaveChanges();

            return Ok(new { message = "Department created", department.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = context.Departments.Find(id);
            if (department == null)
                return NotFound(new { message = "Department not found" });

            context.Departments.Remove(department);
            context.SaveChanges();

            return Ok(new { message = "Department deleted" });
        }

        
        [HttpPatch("{id}")]
        public IActionResult Update(int id, CreateDepartmentDTO request)
        {
            var department = context.Departments.Find(id);
            if (department == null)
                return NotFound(new { message = "Department not found" });

            department.Name = request.Name;
            context.SaveChanges();

            return Ok(new { message = "Department updated" });
        }

    }
}
