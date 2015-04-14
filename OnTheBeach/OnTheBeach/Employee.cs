using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using DomainClasses;
using DataLayer;



namespace OnTheBeach
{
    /// <summary>
    /// EmployeeUI helper class
    /// </summary>
    class EmployeeUI
    {
        /// <summary>
        /// DisplayMenu Function to display the menu 
        /// </summary>
        /// <returns>int</returns>
        public int DisplayMenu()
        {
            Console.WriteLine("Employee Management");
            Console.WriteLine();
            Console.WriteLine("1. Sql query for payment run");
            Console.WriteLine("2. Find salary with employee name");
            Console.WriteLine("3. Staff level employee order by salary");
            Console.WriteLine("4. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
        /// <summary>
        /// FindEmployeeSalaryByName() finds employee salary by the name
        /// </summary>
        public void FindEmployeeSalaryByName()
        {
            string empName;
            BOEmployeeSalary boEmpSal = new BOEmployeeSalary();

            Console.WriteLine("Please enter the name of the employee");
            empName = Console.ReadLine();
            int empId;
            empId=boEmpSal.GetEmployeeIdByName(empName);
            
            if ( empId != -1 && empId !=-2)
            {
                EmployeeSalary empSal = boEmpSal.GetEmployeeSalaryByName(empName);
                string const_EmpSal = "The Salary for " + empSal.EmployeeName
                                      + "in GBP is " + empSal.SalaryInGBP
                                      + " in local currency is " + empSal.SalaryInLocalCurrency;

                Console.WriteLine(const_EmpSal);

            }
            else if (empId !=-2)
            {
               Console.WriteLine("Sorry! There is no employee with that name in the organisation");
            }         
        }
        /// <summary>
        /// DisplayTheQuery is used to display the select query
        /// </summary>

        public void DisplayTheQuery()
        {
            Console.WriteLine("select");
            Console.WriteLine("emp.Id,");
            Console.WriteLine("emp.Name,");
            Console.WriteLine("Cast(Round(sal.Annual_Amount/cur.Conversion_Factor,2) as Numeric(36,2)) as SalaryInGBP ");
            Console.WriteLine("from Employees emp");
            Console.WriteLine("Join Salaries sal on emp.Id=sal.Employee_Id");
            Console.WriteLine("Join Currencies cur on cur.Id=sal.Currency");
        }


        /// <summary>
        /// DisplayStaffEmployees() displays employees with staff role
        /// </summary>
        public void DisplayStaffEmployees()
        {
            List<Employee> empList = new List<Employee>();
            BOEmployeeSalary boEmpSal = new BOEmployeeSalary();
            empList=boEmpSal.GetStaffEmployeeIdOrderBySal();

            foreach (Employee ee in empList)
            {
                Console.WriteLine(ee.Name);
            }
        }
    }
}
