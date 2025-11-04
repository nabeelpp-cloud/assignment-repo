using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDay6
{
    public class Q1
    {
        //Create an extension method ToTitleCase() for the string class that converts the first
        //letter of each word to uppercase.
        public void Question1()
        {
            string str = "a midsummer night's dream";
            string titleString = str.ToTitleCase();
            Console.WriteLine(titleString);
        }
    }
}
