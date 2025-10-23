using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicArrayListOperations
{
    public class LINQWithList
    {
        public void Question5()
        {
            //1.Create a List<string> of 6 names.
            List<string> names = new List<string>();
            names.Add("Nabu");
            names.Add("Bilu");
            names.Add("Vyshnav");
            names.Add("Aswanth");
            names.Add("Jishnu");
            names.Add("Ahin");

            Console.WriteLine("All Names");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            //2.Use LINQ to: 
            //○ Find all names that start with 'A'.
            var nameStartsWithA = names.FindAll(x=>x.StartsWith("A"));
            //○ Find names with length greater than 4.
            var largeNames = names.FindAll(x => x.Length > 4);
            
            //3.Display the results. 

            Console.WriteLine("Names Start With A");
            foreach (string name in nameStartsWithA)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            Console.WriteLine("Names With Length Greater Than 4");
            foreach (string name in largeNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();


        }
    }
}
