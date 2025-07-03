using Crud_in_API.Data;
using Crud_in_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_in_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpGet("")]
        public IActionResult Index()
        {
            var employees = context.Employees
                .Include(e => e.Department)
                .Select(e => new Employee
                {
                    Id = e.Id,
                    Name = e.Name,
                    Salary = e.Salary,
                    DepartmentId = e.DepartmentId,
                    Department = new Department
                    {
                        Id = e.Department.Id,
                        Name = e.Department.Name
                    }
                }).ToList();

            return Ok(employees);
        }

 
        [HttpPost]
        public IActionResult Create([FromBody] Employee request)
        {
            var employee = new Employee
            {
                Name = request.Name,
                Salary = request.Salary,
                DepartmentId = request.DepartmentId
            };

            context.Employees.Add(employee);
            context.SaveChanges();

            return Ok(new { message = "Employee created", employee.Id });
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = context.Employees.Find(id);
           

            context.Employees.Remove(employee);
            context.SaveChanges();

            return Ok(new { message = "Employee deleted" });
        }

        
        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] Employee request)
        {
            var employee = context.Employees.Find(id);
           

            employee.Name = request.Name;
            employee.Salary = request.Salary;
            employee.DepartmentId = request.DepartmentId;

            context.SaveChanges();

            return Ok(new { message = "Employee updated" });
        }
    }
}
