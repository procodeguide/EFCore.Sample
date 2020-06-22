using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProCodeGuide.Samples.EFCore.DbContexts;
using ProCodeGuide.Samples.EFCore.Model;

namespace ProCodeGuide.Samples.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IApplicationDbContext _dbcontext;
        public EmployeeController(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> create([FromBody] Employee employee)
        {
            _dbcontext.Employees.Add(employee);
            await _dbcontext.SaveChanges();
            return Ok(employee.Id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var employees = await _dbcontext.Employees.ToListAsync<Employee>();
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var employee = await _dbcontext.Employees.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            return Ok(employee);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            var employeeupt = await _dbcontext.Employees.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            if (employeeupt == null) return Ok("Employee does not exists");

            employeeupt.Designation = employee.Designation;
            employeeupt.Salary = employee.Salary;

            await _dbcontext.SaveChanges();
            return Ok("Employee details successfully modified");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employeedel = await _dbcontext.Employees.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            if (employeedel == null) return Ok("Employee does not exists");

            _dbcontext.Employees.Remove(employeedel);
            await _dbcontext.SaveChanges();
            return Ok("Employee details deleted modified");
        }
    }
}
