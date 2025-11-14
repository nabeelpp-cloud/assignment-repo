using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
    public class TemperatureConverter
    {

        public double CelsiusToFahrenheit(double celesius)
        {
            TemperatureValidator temperatureValidator = new TemperatureValidator(celesius);
            temperatureValidator.Validate();
            double fahrenheit = celesius * 9 / 5 + 32;
            return fahrenheit;
        }
        public double FahrenheitToCelsius(double fahrenheit)
        {
            double celesius = (fahrenheit - 32) / 1.8 ;
            TemperatureValidator temperatureValidator = new TemperatureValidator(celesius);
            temperatureValidator.Validate();
            return celesius;
        }
        

    }
}
