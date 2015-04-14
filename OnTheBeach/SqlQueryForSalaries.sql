select 
emp.Id,
emp.Name,
Cast(Round(sal.Annual_Amount/cur.Conversion_Factor,2) as Numeric(36,2)) as SalaryInGBP 
from Employees emp
Join Salaries sal on emp.Id=sal.Employee_Id
Join Currencies cur on cur.Id=sal.Currency