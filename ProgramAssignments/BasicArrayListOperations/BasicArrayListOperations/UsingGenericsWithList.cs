using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BasicArrayListOperations
{
    public class UsingGenericsWithList
    {
        public void Question3()
        {
            //1.Create a List<int> to store marks of 5 students.
            //2.Add marks(e.g., 78, 92, 67, 88, 95).
            //3.Calculate and print the average mark.
            //4.Remove the lowest mark.
            //5.Sort the list in ascending order and print the updated list.

            List<int> marks = new List<int>();
            marks.Add(78);
            marks.Add(92);
            marks.Add(67);
            marks.Add(88);
            marks.Add(95);
            Console.WriteLine("Average = "+marks.Average());
            
            int minMark=marks.Min();
            marks.Remove(minMark);

            marks.Sort();
            foreach (int mark in marks) 
            {
                Console.WriteLine(mark);
            }
        }
    }
}
