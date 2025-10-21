using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
    internal class TemperatureValidator
    {
        public double Temperature;
        public TemperatureValidator(double temperature) 
        {
            Temperature = temperature;
        }
        public void Validate() 
        {
            if (Temperature > -273.15 && Temperature < 5500) 
                return;
            else
                Console.WriteLine($"The temparature ({Temperature} in celcius)  is not in the range  (-273.15°C to 5500°C) ");
        }
    }
}
