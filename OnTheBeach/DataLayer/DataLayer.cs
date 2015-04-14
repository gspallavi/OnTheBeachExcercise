using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses;

namespace DataLayer
{
    public class DAEmployee : IDisposable
    {
        /// <summary>
        /// Gets employee salary fromt the database using employee name as key
        /// </summary>
        /// <param name="empName"></param>
        /// <returns>Object of type EmployeeSalary</returns>
      public EmployeeSalary GetSalaryByName(string empName)
        {
            try
            {
                EmployeeEntities dbContext = new EmployeeEntities();
                dbContext.Database.Connection.Open();
                var salary = from emp in dbContext.Employees
                             join sal in dbContext.Salaries on emp.Id equals sal.Employee_Id
                             join cur in dbContext.Currencies on sal.Currency equals cur.Id
                             where emp.Name == empName
                             select new EmployeeSalary
                             {
                                 EmployeeId = emp.Id,
                                 EmployeeName = emp.Name,
                                 SalaryInLocalCurrency = sal.Annual_Amount,
                                 SalaryInGBP = sal.Annual_Amount / cur.Conversion_Factor
                             };

                dbContext.Database.Connection.Close();

                
                return salary.FirstOrDefault().EmployeeId == null ? new EmployeeSalary(): salary.FirstOrDefault();
            }
          catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new EmployeeSalary();
            }
        }
        /// <summary>
      /// This function gets employee id using the name
        /// </summary>
        /// <param name="empName"></param>
        /// <returns>Id of employee</returns>
        public int FindEmployeeIdByName(string empName)
        {
            try
            {
                EmployeeEntities dbContext = new EmployeeEntities();
                dbContext.Database.Connection.Open();
                var employee = from emp in dbContext.Employees
                               where emp.Name == empName
                               select emp.Id;


                dbContext.Database.Connection.Close();
                return employee.FirstOrDefault() == null ? -1 : employee.FirstOrDefault();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -2;
            }
        }
        /// <summary>
        ///  Gets employee salary fromt the database using employee name as key
        /// </summary>
        /// <returns>List of employees</returns>

        public List<Employee> GetStaffEmployeeIdOrderBySal()
        {
               EmployeeEntities dbContext = new EmployeeEntities();
                dbContext.Database.Connection.Open();
                var query = from emp in dbContext.Employees
                               join roles in dbContext.Roles on emp.Role_Id equals roles.Id
                               join sal in dbContext.Salaries on emp.Id equals sal.Employee_Id
                               where roles.Name == "Staff" orderby sal.Annual_Amount descending
                               select emp;

                List<Employee> staffList = new List<Employee>();
                staffList = query.ToList();
                return staffList;                           
        }
        /// <summary>
        /// Implementation for IDisposable
        /// </summary>

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
       
   
}
