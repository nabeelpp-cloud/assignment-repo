using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.day3sub
{
    public class Student
    {
        public string Name;
        public int Age;
        public Student(string  name, int age)
        {
            Name = name;
            Age = age;
        }
        public void Display()
        {
            Console.WriteLine($"{Name} is {Age} years old.");
        }
    }
}
