using Microsoft.EntityFrameworkCore;
using ProCodeGuide.Samples.EFCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.Samples.EFCore.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; set; }

        Task<int> SaveChanges();
    }
}
