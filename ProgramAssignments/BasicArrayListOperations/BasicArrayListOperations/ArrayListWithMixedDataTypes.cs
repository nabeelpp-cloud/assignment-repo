using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BasicArrayListOperations
{
    public class ArrayListWithMixedDataTypes
    {
        public void Question2()
        {
            //1.Create an ArrayList and add the following elements:
            //○ A string("John")
            //○ An integer(25) 
            //○ A double(75.5)
            //○ A boolean(true) 
            //2.Iterate through the list and print each element along with its data type using
            //GetType(). 

            ArrayList arrayList = new ArrayList();
            arrayList.Add("John");
            arrayList.Add(25);
            arrayList.Add(75.5);
            arrayList.Add(true);

            foreach (var item in arrayList) 
            {
                Console.WriteLine($"Data type of {item} is {item.GetType()}  ");
            }
        }
    }
}
