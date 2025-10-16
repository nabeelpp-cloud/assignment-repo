using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    public class AssignmentDay2()
    {

        public void AssDay2()
        {
            //First20Numbers();
            //OddLessThan50();
            //LargestOfThree();
            //ReverseNumber();
            //SumOfDigits();
            //CheckPrime();
            //PrimeNumbersBelow100();
            //FibonacciSeriesPrint();
            //TaxCalculation();
            SportsName();
        }

        //Print first 20 numbers using for loop
        public static void First20Numbers()
        {
            Console.WriteLine("First 20 numbers");
            for(int i=1;i<=20;i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
        //Print odd numbers less than 50 using while loop
        public static void OddLessThan50()
        {
            Console.WriteLine("Odd numbers less than 50");
            int i = 1;
            while (i < 50)
            {
                Console.WriteLine(i);
                i += 2;
            }
            Console.WriteLine();

        }

        //Large amount 3 numbers
        public static void LargestOfThree()
        {
            Console.WriteLine("Largest of Three numbers");
            int a, b, c;
            Console.Write("Enter first number: ");
            a=int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            b=int.Parse(Console.ReadLine());
            Console.Write("Enter third number: ");
            c=int.Parse(Console.ReadLine());
            if(a>b && a>c)
            {
                Console.WriteLine("First number is largest:"+a);
            }
            else if(b>c)
            {
                Console.WriteLine("Second number is largest:"+b);
            }
            else
            {
                Console.WriteLine("Third number is largest:"+c);
            }
            Console.WriteLine();

        }

        //Reverse of a number
        public static void ReverseNumber()
        {
            Console.WriteLine("Reverse of a number");
            int num, reverse = 0;
            Console.Write("Enter a number: ");
            num = int.Parse(Console.ReadLine());
            while (num != 0)
            {
                int digit = num % 10;
                reverse = reverse * 10 + digit;
                num /= 10;
            }
            Console.WriteLine("Reversed Number: " + reverse);
            Console.WriteLine();
        }

        //Sum of the digits of a number
        public static void SumOfDigits()
        {
            Console.WriteLine("Sum of the digits of a number");
            int num, sum = 0;
            Console.Write("Enter a number: ");
            num = int.Parse(Console.ReadLine());
            while (num != 0)
            {
                int digit = num % 10;
                sum += digit;
                num /= 10;
            }
            Console.WriteLine("Sum of Digits: " + sum);
            Console.WriteLine();
        }

        //Check prime number
        public static void CheckPrime()
        {
            Console.WriteLine("Check prime number");
            int num;
            Console.Write("Enter a number: ");
            num = int.Parse(Console.ReadLine());
            bool isPrime = true;
            for (int i  = 2; i  <= num/2; i ++)
            {
                if(num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if(isPrime)
            {
                Console.WriteLine(num + " is a prime number");
            }
            else
            {
                Console.WriteLine(num + " is not a prime number");
            }
            Console.WriteLine();
        }

        //Print all prime numbers below 100
        public static void PrimeNumbersBelow100()
        {
            Console.WriteLine("Prime numbers below 100:");
            for(int num=2;num<100;num++)
            {
                bool isPrime = true;
                for(int i=2;i<=num/2;i++)
                {
                    if(num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if(isPrime)
                {
                    Console.WriteLine(num);
                }
            }
            Console.WriteLine();
        }

        //Fibonacci series
        public static void FibonacciSeriesPrint()
        {
            Console.WriteLine("Fibonacci series");
            int num;
            Console.Write("Enter a number: ");
            num = int.Parse(Console.ReadLine());
            int a = 0, b = 1, c;
            for(int i=0;i<num;i++)
            {
                Console.Write(a + " ");
                c = a + b;
                a = b;
                b = c;
            }
            Console.WriteLine();
        }

        //Tax calculation program, input the amount and display the tax

        //Amount
        //Tax %
        //Less than 10000
        //5
        //Between 10000 and 15000
        //7.5
        //Between 15000 and 20000
        //10
        //Between 20000 and 25000
        //12.5
        //Above 25000
        //15

        public static void TaxCalculation()
        {
            Console.WriteLine("Tax calculation program");
            Console.Write("Enter the amount: ");
            double amount=double.TryParse(Console.ReadLine(), out amount) ? amount : 0;
            double tax = 0;
            if (amount <= 0)
                tax = 0;
            else if (amount < 10000)
                tax = amount * 0.05;
            else if(amount<=15000)
                tax = amount * 0.075;
            else if(amount<=20000)
                tax = amount * 0.10;
            else if(amount<=25000)
                tax = amount * 0.125;
            else
                tax = amount * 0.15;
            Console.WriteLine("Tax: " + tax);
        }

        //Input a character from console and display the sports name corresponding to it

        //character
        //Sports
        //c
        //Cricket
        //f
        //Football
        //h
        //Hockey
        //t
        //Tennis
        //b
        //Badminton


        public static void SportsName() 
        {
            Console.WriteLine("Sports name program");
            Console.Write("Enter a character (c,f,h,t,b): ");
            char ch = char.TryParse(Console.ReadLine(), out ch) ? ch : ' ';
            switch(ch)
            {
                case 'c':
                    Console.WriteLine("Cricket");
                    break;
                case 'f':
                    Console.WriteLine("Football");
                    break;
                case 'h':
                    Console.WriteLine("Hockey");
                    break;
                case 't':
                    Console.WriteLine("Tennis");
                    break;
                case 'b':
                    Console.WriteLine("Badminton");
                    break;
                default:
                    Console.WriteLine("Invalid character");
                    break;
            }
        }
    }
}
