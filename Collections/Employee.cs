using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.Collections
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public double  Salary { get; set; }

    }

    public class Organization:IEnumerable
    {
        List<Employee> Emps = new List<Employee>();
        public void Add(Employee emp)
        { 
            Emps.Add(emp);
        }

        public IEnumerator GetEnumerator()
        {
            return Emps.GetEnumerator();
        }

         
    }

    class TestEmployee
    {
        static void Main()
        {
            Organization Employees = new Organization();
            Employees.Add(new Employee { ID = 101, Name = "Raju", Job = "Manager", Salary = 25000.00 });
            Employees.Add(new Employee { ID = 102, Name = "David", Job = "Analyst", Salary = 35000.00 });
            Employees.Add(new Employee { ID = 103, Name = "Peter", Job = "Salesman", Salary = 15000.00 });
            Employees.Add(new Employee { ID = 104, Name = "Venkat", Job = "Salesman", Salary = 15000.00 });
            Employees.Add(new Employee { ID = 105, Name = "Ajay", Job = "Manager", Salary = 25000.00 });
            Employees.Add(new Employee { ID = 106, Name = "John", Job = "Clerk", Salary = 15000.00 });
            Employees.Add(new Employee { ID = 107, Name = "Tom", Job = "Developer", Salary = 45000.00 });

            foreach (Employee employee in Employees)
                Console.WriteLine(employee.ID+" "+employee.Name+" "+ employee.Job+" "+employee.Salary) ;
        }
    }
}
