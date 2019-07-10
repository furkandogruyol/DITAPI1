using System;
using System.Collections.Generic;

namespace APIDIT.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Case = new HashSet<Case>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeePhone { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeInsurance { get; set; }
        public double EmployeeSalary { get; set; }
        public double EmployeeWorkhour { get; set; }
        public DateTime EmployeeBirthdate { get; set; }

        public ICollection<Case> Case { get; set; }
    }
}
