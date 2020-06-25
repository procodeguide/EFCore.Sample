using ProCodeGuide.Samples.EFCore.DbContexts;
using ProCodeGuide.Samples.EFCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.Samples.EFCore.Repository
{
    public interface IEmployeeRepository
    {
        Task<int> Create(Employee employee);
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<string> Update(int id, Employee employee);
        Task<string> Delete(int id);
    }
}
