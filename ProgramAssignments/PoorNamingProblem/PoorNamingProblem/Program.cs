// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using PoorNamingProblem;

Employee employee = new Employee("Nabeel",24,25000);
Console.WriteLine("Name = " + employee.Name);
Console.WriteLine("Age = "+employee.Age);
Console.WriteLine("Salary = "+employee.Salary);
employee.CalculateBonus();