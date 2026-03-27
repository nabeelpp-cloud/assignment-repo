using System;

namespace EmployeeManagement
{
    public class Employee
    {
        private const int StartId = 1000;
        private static int _counter = StartId;
        private readonly string _id;
        public static string IdPrefix { get; set; } = "Emp";
        public string Name { get; set; }
        public double Salary { get; set; }
        public string EmployeeType { get; set; }

        public Employee(string name, double salary, string employeeType)
        {
            _id = $"{IdPrefix}{ _counter}";
            _counter++;
            Name = name;
            Salary = salary;
            EmployeeType = employeeType;
        }

        public static int EmployeeCount()
        {
            return _counter - StartId;

        }

        public static string NextEmployeeId()
        {
            return  $"{IdPrefix}{_counter}";
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"{_id}\t{Name}\t{Salary}\t{EmployeeType}");
        }
    }
}
