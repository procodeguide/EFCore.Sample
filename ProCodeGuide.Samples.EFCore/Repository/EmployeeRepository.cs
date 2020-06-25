using Microsoft.EntityFrameworkCore;
using ProCodeGuide.Samples.EFCore.DbContexts;
using ProCodeGuide.Samples.EFCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.Samples.EFCore.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IApplicationDbContext _dbcontext;
        public EmployeeRepository(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Create(Employee employee)
        {
            _dbcontext.Employees.Add(employee);
            await _dbcontext.SaveChanges();
            return employee.Id;
        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = await _dbcontext.Employees.ToListAsync<Employee>();
            return employees;
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _dbcontext.Employees.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            return employee;
        }

        public async Task<string> Update(int id, Employee employee)
        {
            var employeeupt = await _dbcontext.Employees.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            if (employeeupt == null) return "Employee does not exists";

            employeeupt.Designation = employee.Designation;
            employeeupt.Salary = employee.Salary;

            await _dbcontext.SaveChanges();
            return "Employee details successfully modified";
        }

        public async Task<string> Delete(int id)
        {
            var employeedel = _dbcontext.Employees.Where(empid => empid.Id == id).FirstOrDefault();
            if (employeedel == null) return "Employee does not exists";

            _dbcontext.Employees.Remove(employeedel);
            await _dbcontext.SaveChanges();
            return "Employee details deleted modified";
        }
    }
}
