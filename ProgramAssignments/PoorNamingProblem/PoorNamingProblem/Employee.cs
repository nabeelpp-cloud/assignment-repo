using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoorNamingProblem
{
    public class Employee
    {
        public string Name; 
        public int Age;
        public double Salary;
        public Employee(string name,int age,double salary) 
        {
            Name = name;
            Age = age;
            Salary = salary;
        }
        public void CalculateBonus()
        {
            double bonus = Salary * 0.1;
            double totalSalary = Salary + bonus;
            Console.WriteLine($"Total Salary = {totalSalary}");
        }
    }
}
