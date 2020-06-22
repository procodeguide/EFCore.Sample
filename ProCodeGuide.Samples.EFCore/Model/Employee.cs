using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.Samples.EFCore.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }
    }
}
