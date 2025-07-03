using Crud_in_API.Data;
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
            var departments = context.Departments
                .Include(d => d.Employees)
                .Select(d => new Department
                {
                    Id = d.Id,
                    Name = d.Name,
                    Employees = d.Employees.Select(e => new Employee
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Salary = e.Salary
                    }).ToList()
                }).ToList();

            return Ok(departments);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Department request)
        {
            var department = new Department
            {
                Name = request.Name
            };

            context.Departments.Add(department);
            context.SaveChanges();

            return Ok(new { message = "Department created", department.Id });
        }

        // DELETE: api/Departments/5
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

        // PATCH: api/Departments/5
        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] Department request)
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
