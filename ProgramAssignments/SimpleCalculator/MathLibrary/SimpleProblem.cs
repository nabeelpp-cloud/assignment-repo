using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class SimpleProblem
    {
        public void Addition(int a,int b)
        {
            Console.WriteLine($"Result = {a+b}");
        }
        public void Subtraction(int a, int b) 
        {
            Console.WriteLine($"Result = {a - b}");
        }
        public void Multiplication(int a, int b) 
        {
            Console.WriteLine($"Result = {a * b}");
        }
        public void Division(int a, int b)
        {
            try
            {
                //int res = a / b ;
                //Console.WriteLine(res);
                if (b == 0)
                    throw new DivideByZeroException("DivideByZeroException : You tried to devide by zero");
                Console.WriteLine("Result = "+ (double)a / (double)b);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Modulus(int a, int b)
        {
            try
            {
                Console.WriteLine($"Result = {a % b}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
