using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class EmployeeSalary
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal? SalaryInGBP { get; set; }
        public int? SalaryInLocalCurrency { get; set; }
    }
}
