using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDay6
{
    public class Q3
    {
        //Create a base class Animal with a virtual method Speak(). Then create two derived
        //classes: Dog and Cat, that override the Speak() method.
        public void Question3()
        {
            Animal dog = new Dog();
            dog.Speack();

            Animal cat = new Cat();
            cat.Speack();
        }
    }
    public class Animal() 
    {
        public virtual void Speack()
        {
            Console.WriteLine("Inside animal");
        }
    }
    public class Dog() : Animal
    {
        public override void Speack() 
        {
            Console.WriteLine("Inside Dog");
        }
    }
    public class Cat() : Animal
    {
        public override void Speack() 
        {
            Console.WriteLine("Inside Cat");
        }
    }

}
