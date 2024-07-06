using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.Collections
{
    public class Customer
    {
        public int CustID { get; set; }
        public string Name { get; set; }
        public string  City { get; set; }
        public double  Balance { get; set; }
    }

    class TestCustomer
    {
        //static void Main(string[] args)
        //{
        //    Customer c1 = new Customer { CustID = 101, Name = "Scott", City = "Hyderabad", Balance = 25000.00 };
        //    Customer c2 = new Customer { CustID = 102, Name = "Mecheal", City = "Chennai", Balance = 29000.00 };
        //    Customer c3 = new Customer { CustID = 103, Name = "Smith", City = "Delhi", Balance = 35000.00 };
        //    Customer c4 = new Customer { CustID = 104, Name = "John", City = "Hyderabad", Balance = 59000.00 };
        //    List<Customer> customers = new List<Customer>() { c1,c2,c3,c4};

        //    //customers.Add(c1);
        //    //customers.Add(c2);
        //    //customers.Add(c3);
        //    //customers.Add(c4);

        //    foreach (Customer customer in customers)
        //    {
        //        Console.WriteLine(customer.CustID + " " + customer.Name + " " + customer.City + " " + customer.Balance);
        //    }
        //}
    }
}
