using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Employee
    {
        private static string _id;
        public static int counter;
        public string Name;
        public double Salary;
        public EmployeeType EmpType;
        public enum EmployeeType
        {
            Permanent,
            Contract
        }
        static Employee()
        {
            counter = 1000;  
        }
        public Employee(string name, double salary, EmployeeType employeeType) 
        {
            _id = "Emp" + counter;
            counter++;
            Name = name;
            Salary = salary;
            EmpType=employeeType;
        }

        public static int EmployeeCount()
        {
            return counter-1000;
        }
        public static string NextEmployeeId()
        {
            return "Emp"+counter;
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"{_id}\t\t{Name}\t{Salary}\t\t{EmpType}");
        }
    }
}
