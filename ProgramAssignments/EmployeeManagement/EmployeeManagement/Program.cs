// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using EmployeeManagement;
using System.Diagnostics.Contracts;

Employee employee1 = new Employee("John Doe",15000,Employee.EmployeeType.Permanent);
Employee employee2 = new Employee("Liam Smith", 20000,Employee.EmployeeType.Contract);
Employee employee3 = new Employee("Mary James", 15000,Employee.EmployeeType.Permanent);

int empCount=Employee.EmployeeCount();
Console.WriteLine($"Employee Count: {empCount}");
string nextEmpId=Employee.NextEmployeeId();
Console.WriteLine($"Next Aavailable Employee Id: {nextEmpId}");

Console.WriteLine("\nEmplyee Details\n");
Console.WriteLine("EmpId\t\tEmpName\t\tSalary\t\tEmpType\n");
employee1.DisplayDetails();
employee2.DisplayDetails();
employee3.DisplayDetails();