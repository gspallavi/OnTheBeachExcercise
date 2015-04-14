using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnTheBeach
{
    /// <summary>
    /// Main Program
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeUI emp = new EmployeeUI();
            int key;
            do
            {                 
                key=emp.DisplayMenu();
                switch (key)
                {
                    case 1:
                        emp.DisplayTheQuery();
                        break;
                    case 2:
                        emp.FindEmployeeSalaryByName();
                        break;
                    case 3:
                        emp.DisplayStaffEmployees();
                        break;
                }
            } while (key != 4 );

        }
       
    }
}
