using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AssignmentDay6
{
    public class Q2
    {
        //● Create an extension method AverageExceptZero() for List<int> that calculates the
        //average excluding zero values.
        //Sample Date :  
        //List<int> numbers = new List<int> { 10, 0, 20, 30, 0 };
        //Console.WriteLine(numbers.AverageExceptZero()); // Output : 20 
        public void Question2()
        {
            List<int> numbers = new List<int> { 10, 0, 20, 30, 0 };
            Console.WriteLine(numbers.AverageExceptZero());
        }
    }
}
