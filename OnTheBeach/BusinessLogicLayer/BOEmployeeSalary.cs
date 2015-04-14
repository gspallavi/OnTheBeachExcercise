using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DomainClasses;


namespace BusinessLogicLayer
{
    public class BOEmployeeSalary
    {
        /// <summary>
        /// GetEmployeeSalaryByName() gets employee salary fromt the database using employee name as key
        /// </summary>
        /// <param name="empName"></param>
        /// <returns>Object EmployeeSalary</returns>
        public EmployeeSalary GetEmployeeSalaryByName(string empName)
        {
            using (DAEmployee dae = new DAEmployee())
            {
                return dae.GetSalaryByName(empName);
            }
        }
        /// <summary>
        /// This function gets employee id using the name
        /// </summary>
        /// <param name="empName"></param>
        /// <returns>employee id</returns>

        public int GetEmployeeIdByName(string empName)
        {
            using (DAEmployee dae = new DAEmployee())
            {
                return dae.FindEmployeeIdByName(empName);
            }
        }
        /// <summary>
        /// This function gets employees with role staff in order of their salary
        /// </summary>
        /// <returns>List of staff employees</returns>
        public List<Employee> GetStaffEmployeeIdOrderBySal()
        {
            using (DAEmployee dae = new DAEmployee())
            {
                return dae.GetStaffEmployeeIdOrderBySal();
            }

        }
    }

     
}
