using Azure.Core;
using Crud_in_API.Data;
using Crud_in_API.DTO.EmployeeDTO;
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
                .Select(e => new CreateEmployeeDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    Salary = e.Salary,
                    DepartmentId = e.DepartmentId,
                }).ToList();

            return Ok(employees);
        }

 
        [HttpPost]
        public IActionResult Create(CreateEmployeeDTO request)
        {
            var Emp = new Employee
            {
                Name = request.Name,
                Salary = request.Salary,
                DepartmentId = request.DepartmentId,
            };

            context.Employees.Add(Emp);
            context.SaveChanges();

            return Ok(new { message = "Employee created", Emp.Id });
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
        public IActionResult Update(int id, CreateEmployeeDTO request)
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
