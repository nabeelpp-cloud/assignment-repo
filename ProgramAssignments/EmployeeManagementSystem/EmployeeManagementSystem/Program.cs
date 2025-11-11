// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using EmployeeManagementSystem;
using System.Numerics;
using System.Xml.Linq;
using static EmployeeManagementSystem.Employee;

Console.WriteLine("Welcome to the Employee Management System");
bool isContinue=true;


while (isContinue)
{
    Console.WriteLine("Main Menu ");
    Console.WriteLine("1.Add Employee\r\n2. Remove Employee \r\n3. Display All Employees \r\n4. Search Employee \r\n5. Exit\n");
    Console.Write("Choose your Option (1-5) : ");
    int choice=int.Parse(Console.ReadLine());
    

    switch (choice)
    {
        case 1:
            AddEmployee();
            break;
        case 2:
            RemoveEmployee();
            break;
        case 3:
            DisplayAllEmployee();
            break;
        case 4:
            SearchEmployee();
            break;
        case 5: 
            isContinue=false; 
            break;
        default:Console.WriteLine("Invalid Choice");
            break;
    }

}
