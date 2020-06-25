using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProCodeGuide.Samples.EFCore.DbContexts;
using ProCodeGuide.Samples.EFCore.Model;
using ProCodeGuide.Samples.EFCore.Repository;

namespace ProCodeGuide.Samples.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeerepository;
        public EmployeeController(IEmployeeRepository employeerepository)
        {
            _employeerepository = employeerepository;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> create([FromBody] Employee employee)
        {
            int empid = await _employeerepository.Create(employee);
            return Ok(empid);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var employees = await _employeerepository.GetAll();
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var employee = await _employeerepository.GetById(id);
            return Ok(employee);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            string resp = await _employeerepository.Update(id, employee);
            return Ok(resp);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resp = await _employeerepository.Delete(id);
            return Ok(resp);
        }
    }
}
