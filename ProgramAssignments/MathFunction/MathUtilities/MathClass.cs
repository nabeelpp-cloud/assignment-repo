using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtilities
{
    public class MathClass
    {

        public bool IsEven(int num)
        {
            if (num % 2 == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsPrime(int num)
        {
            bool isPrime = true;
            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }
        public int Factorial(int num)
        {
            int fact = 1;
            for (int i = 1; i <= num; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }
}
