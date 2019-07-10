using System;
using System.Collections.Generic;

namespace APIDIT.Models
{
    public partial class Case
    {
        public int CaseId { get; set; }
        public int? EmployeeId { get; set; }
        public double? MoneyAmount { get; set; }

        public Employee Employee { get; set; }
    }
}
