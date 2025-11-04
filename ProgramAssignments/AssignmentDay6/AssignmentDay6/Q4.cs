using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDay6
{
    public class Q4
    {
        //Create a base class Vehicle with a method ShowType() that prints "This is a vehicle". 
        //Then create a derived class Car that hides the ShowType() method using the new
        //keyword and prints "This is a car". 
        //Call the method using both base class and derived class references to see the
        //difference.
        public void Question4()
        {
            Vehicle vehicle = new Car();
            vehicle.ShowType();

            Car car = new Car();
            car.ShowType();

            
        }
    }
    public class Vehicle
    {
        public virtual void ShowType()
        {
            Console.WriteLine("This is a vehicle");
        }
    }
    public class Car():Vehicle
    {
        public new void ShowType()
        {
            Console.WriteLine("This is a car");
        }
    }
}
