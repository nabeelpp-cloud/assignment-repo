using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BasicArrayListOperations
{
    public class BasicArrayListOperation
    {


        //Basic ArrayList Operations 
        //1. Create an ArrayList to store student names. 
        //2. Add 5 student names to the list. 
        //3. Display all names. 
        //4. Remove one name from the list. 
        //5. Insert a new name at index 2. 
        //6. Print the final list using both a for loop and a foreach loop.

        public void Question1()
        {
            ArrayList studentNames = new ArrayList();
            studentNames.Add("Nabeel");
            studentNames.Add("Mafas");
            studentNames.Add("Nipun");
            studentNames.Add("Abhinav");
            studentNames.Add("Karthik");

            foreach (string studentName in studentNames)
            {
                Console.WriteLine(studentName);
            }
            Console.WriteLine();
            Console.WriteLine("Removed Nabeel");
            Console.WriteLine();
            studentNames.Remove("Nabeel");
            foreach (string studentName in studentNames)
            {
                Console.WriteLine(studentName);
            }
            Console.WriteLine();
            Console.WriteLine("Added Nabeel at Index 2");
            Console.WriteLine();
            studentNames.Insert(2, "Nabeel");

            foreach (string studentName in studentNames)
            {
                Console.WriteLine(studentName);
            }
            Console.WriteLine();
            for (int i = 0; i < studentNames.Count; i++)
            {
                Console.WriteLine(studentNames[i]);
            }
        }
    }

}

