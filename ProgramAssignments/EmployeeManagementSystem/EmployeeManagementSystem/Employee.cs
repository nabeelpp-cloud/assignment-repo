using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeManagementSystem
{
    public class Employee
    {
        public static int idNo = 1000;
        public string Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public EmployeeType EmpType { get; set; }
        public enum EmployeeType
        {
            Permanent,
            Contract
        }
        public static List<Employee> EmployeeList = new List<Employee>();

        public Employee(string name, double salary, string empType)
        {
            Id = "Emp" + idNo;
            idNo++;
            Name = name;
            Salary = salary;
            EmpType = empType == "Permanent" ? EmployeeType.Permanent : EmployeeType.Contract;

        }
        public static void AddEmployee()
        {
            Console.WriteLine("\nAdd New Employee");
            Console.Write("Enter Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Salary : ");
            double salary = double.Parse(Console.ReadLine());
            string empType = "";
            while (true)
            {
                Console.Write("Choose Employee Type \n1-Permanent \n2-Contract \nChoose Your Option ( 1/2 ) :");
                int choice2 = int.Parse(Console.ReadLine());
                if (choice2 == 1)
                {
                    empType = "Permanent";
                    break;
                }
                else if (choice2 == 2)
                {
                    empType = "Contract";
                    break;
                }
                else
                    Console.WriteLine("\nInvalide Choice\n");
            }
            Employee employee = new Employee(name, salary, empType);

            Console.WriteLine($"\nNew Employee ADDED Successfully\n" +
                $"\nEmployee Id : {employee.Id} " +
                $"\nEmployee Name : {employee.Name}" +
                $"\nEmployee Salary : {employee.Salary}" +
                $"\nEmployee Type : {employee.EmpType}");
            Console.WriteLine("\nGoing To Main Menu\n");
            EmployeeList.Add(employee);
        }
        public static void RemoveEmployee()
        {
            Console.WriteLine("\nRemove Employee\n");
            Console.Write("Enter Id : ");
            var id = Console.ReadLine();
            var removeEmployee = EmployeeList.FirstOrDefault(x => x.Id == id);
            if (removeEmployee == null)
            {
                Console.WriteLine("Employee Not Found");
                Console.WriteLine("\nGoing To Main Menu\n");
                return;
            }

            EmployeeList.Remove(removeEmployee);
            Console.WriteLine($"\nRemoved the Employee {removeEmployee.Id} {removeEmployee.Name} Successfully\n");
        }
        public static void DisplayAllEmployee()
        {

            if (EmployeeList.Count == 0)
            {
                Console.WriteLine("\nEmployee List is Empty\n");
                return;
            }
            Console.WriteLine("\nAll Employee Details\n");
            Console.WriteLine("\nEmpId\t\tName\t\tSalary\t\tEmpType\n");
            foreach (var emp in EmployeeList)
            {
                Console.WriteLine($"{emp.Id}\t\t{emp.Name}\t\t{emp.Salary}\t\t{emp.EmpType}");
            }
            Console.WriteLine();
        }
        public static void SearchEmployee()
        {
            Console.Write("Enter Name To Search : ");
            string searchName = Console.ReadLine();
            var searchEmployee = EmployeeList.FirstOrDefault(x => x.Name == searchName);
            if (searchEmployee == null)
            {
                Console.WriteLine("Employee Not Found");
                Console.WriteLine("\nGoing To Main Menu\n");
                return;
            }
            Console.WriteLine($"\nEmpId : {searchEmployee.Id}");
            Console.WriteLine($"Name : {searchEmployee.Name}");
            Console.WriteLine($"Salary : {searchEmployee.Salary}");
            Console.WriteLine($"EmpType : {searchEmployee.EmpType}");
            Console.WriteLine("\nGoing To Main Menu\n");
        }
    }
}
