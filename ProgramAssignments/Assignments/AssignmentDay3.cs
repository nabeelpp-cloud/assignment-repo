using Assignments.day3sub;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignments
{
    public class AssignmentDay3
    {
        public void AssDay3()
        {
            //ArithmeticOperations();
            //EvenOdd();
            //CompareTwoIntegers();
            //SwapTwoNumbers();
            //CheckNumberInRange();
            //SimpleCalculator();
            //StudentClass();
            EmployeeClass();
            //BankAccountClass();
            //SwapTwoNumbersUsingRef();
            //OutExample1();
            //OutExample2();
        }


        //1-Input two numbers and perform all arithmetic operations(+, -, *, /, %).
        public void ArithmeticOperations()
        {
            Console.WriteLine("Arithmetic Operations");
            int a, b;
            Console.Write("Enter first number: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Addition: {a + b}");
            Console.WriteLine($"Subtraction: {a - b}");
            Console.WriteLine($"Multiplication: {a * b}");
            if (b == 0)
            {
                Console.WriteLine("Division: undefined");
                Console.WriteLine("Modulus: undefined");
            }
            else 
            {
                Console.WriteLine($"Division: {(float)a / (float)b}");
                Console.WriteLine($"Modulus: {a % b}");
            }
        }


        //2-Check whether a number is even or odd using the ternary operator.
        public void EvenOdd()
        {
            Console.WriteLine("Check Even or Odd");
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            string result = (num % 2 == 0) ? "Even" : "Odd";
            Console.WriteLine($"{num} is {result}");
        }

        //3-Compare two integers using relational and logical operators.
        public void CompareTwoIntegers()
        {
            Console.WriteLine("Compare Two Integers");
            int a, b;
            Console.Write("Enter first number: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            b = int.Parse(Console.ReadLine());
            if (a == b)
            {
                Console.WriteLine("Both numbers are equal");
            }
            else if (a > b)
            {
                Console.WriteLine($"{a} is greater than {b}");
            }
            else
            {
                Console.WriteLine($"{b} is greater than {a}");
            }
        }

        //4-Swap two numbers without using a third variable(use arithmetic).
        public void SwapTwoNumbers()
        {
            Console.WriteLine("Swap Two Numbers");
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Before Swapping: a={a}, b={b}");
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"After Swapping: a={a}, b={b}");
        }

        //5-Check if a number lies between 10 and 50 using logical operators.
        public void CheckNumberInRange()
        {
            Console.WriteLine("Check Number in Range 10 to 50");
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            if (num >= 10 && num <= 50)
            {
                Console.WriteLine($"{num} lies between 10 and 50");
            }
            else
            {
                Console.WriteLine($"{num} does not lie between 10 and 50");
            }
        }


        //6-Simulate a simple calculator using a switch statement and arithmetic operators.
        public void SimpleCalculator()
        {
            Console.WriteLine("Simple Calculator");
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter an operator (+, -, *, /, %): ");
            char op = Console.ReadLine()[0];
            switch (op)
            {
                case '+':
                    Console.WriteLine($"Result: {a + b}");
                    break;
                case '-':
                    Console.WriteLine($"Result: {a - b}");
                    break;
                case '*':
                    Console.WriteLine($"Result: {a * b}");
                    break;
                case '/':
                    if (b != 0)
                        Console.WriteLine($"Result: {a / b}");
                    else
                        Console.WriteLine("Division by zero is not allowed");
                    break;
                case '%':
                    if (b != 0)
                        Console.WriteLine($"Result: {a % b}");
                    else
                        Console.WriteLine("Mod by zero is not allowed");
                    break;
                default:
                    Console.WriteLine("Invalid operator");
                    break;
            }
        }

        //7-Create a class Student with fields Name and Age.
        //  Add a constructor to initialize them and display details in a separate method.
        public void StudentClass()
        {
            Console.WriteLine("Student Class");
            Console.Write("Enter Name :");
            string name = Console.ReadLine();
            Console.Write("Enter Age :");
            int age = int.Parse(Console.ReadLine());
            Student student = new Student(name, age);
            student.Display();
        }


        //8-Create a class Employee with two constructors(Name only; Name, Salary) using constructor chaining.
        public void EmployeeClass()
        {
            Console.WriteLine("Employee Class");
            Console.Write("Enter Employee Name :");
            string name = Console.ReadLine();
            Employee employee1 = new Employee(name);
            employee1.Display();
            Employee employee2 = new Employee(name, 50000);
            employee2.Display();
        }

        //9-Create a class BankAccount(AccountNumber, AccountHolder, Balance ) with default and parameterized constructors
        //  using constructor chaining.Add Deposit() which increments the balance and DisplayBalance() to display the
        //  account details methods.
        public void BankAccountClass()
        {
            Console.WriteLine("Bank Account Class");
            Console.Write("Enter Account Number :");
            int accNo = int.Parse(Console.ReadLine());
            Console.Write("Enter Account Holder Name :");
            string accName = Console.ReadLine();
            BankAccount account = new BankAccount(accNo, accName, 1000);
            Console.WriteLine();
            account.ViewBalance();
            Console.WriteLine();
            Console.Write("Enter amount to deposit: ");
            double amount = double.Parse(Console.ReadLine());
            Console.WriteLine();
            account.Deposite(amount);
            Console.WriteLine();
            account.ViewBalance();
        }

        //10-Swap two integers using the ref keyword.
        public void SwapTwoNumbersUsingRef()
        {
            Console.WriteLine("Swap Two Numbers");
            Console.Write("Enter first number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"Before Swapping: num1 = {num1}, num2 = {num2}");
            Swap(ref num1, ref num2);
            Console.WriteLine($"After Swapping: num1 = {num1}, num2 = {num2}");
        }
        public void Swap(ref int a, ref int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
        }

        //11-Write a method GetSumAndAverage(int a, int b, out int sum, out double avg) that returns sum and
        //  average using out parameters.
        public void OutExample1()
        {
            Console.WriteLine("Out Example 1");
            Console.Write("Enter first number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine());
            GetSumAndAverage(num1, num2, out int sum, out double average);
            Console.WriteLine($"Sum: {sum}, Average: {average}");
        }
        public void GetSumAndAverage(int a, int b, out int sum, out double average)
        {
            sum = a + b;
            average = sum / 2.0;
        }

        //12-Write a method FindMaxMin(int[] arr, out int max, out int min) that finds maximum and minimum using out.
        public void OutExample2()
        {
            Console.WriteLine("Out Example 2");
            Console.WriteLine("Enter 5 elemets");
            int[] numbers = new int[5];
            for (int i = 0; i < 5; i++)
            {
                numbers[i] = int.TryParse(Console.ReadLine(), out int result)?result:0;
            }
            FindMaxMin(numbers, out int max, out int min);
            Console.WriteLine($"Maximum: {max}, Minimum: {min}");
        }
        public void FindMaxMin(int[] nums, out int maximum, out int minimum)
        {
            maximum = nums[0];
            minimum = nums[0];
            for (int i=0;i<nums.Length;i++)
            {
                if (nums[i] > maximum)
                    maximum = nums[i];
                if (nums[i] < minimum)
                    minimum = nums[i];
            }
            
        }
    }
}
