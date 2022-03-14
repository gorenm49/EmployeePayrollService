using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    public class EmpData_Model
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal salary { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public decimal basic_pay { get; set; }
        public decimal deduction { get; set; }
        public decimal taxable_pay { get; set; }
        public decimal income_tax { get; set; }
        public decimal net_pay { get; set; }
        public DateTime startDate { get; set; }
    }
}
