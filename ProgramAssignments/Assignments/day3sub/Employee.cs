using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.day3sub
{
    public class Employee
    {
        public string EmployeeName;
        public double Salary;
        public Employee() 
        {
            Salary = 0; 
        }
        public Employee(string name) 
        {
            EmployeeName = name;
        }
        public Employee(string name, double salary) : this(name)
        {
            Salary = salary;
        }
        public void Display()
        {
            Console.WriteLine($"Employee Name: {EmployeeName}, Salary: {Salary}");
        }
    }
}
