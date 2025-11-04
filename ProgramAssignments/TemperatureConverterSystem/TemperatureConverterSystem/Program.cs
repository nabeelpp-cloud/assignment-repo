// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");



TemperatureConverter.TemperatureConverter temperatureConverter1 = new TemperatureConverter.TemperatureConverter();

//Temp in range

double temp1 = temperatureConverter1.CelsiusToFahrenheit(37);
Console.WriteLine("Fahrenheits of 37 = " + temp1);
double temp2 = temperatureConverter1.FahrenheitToCelsius(100);
Console.WriteLine("Celsius degree of 100 = " + temp2);

//Temp Out of Range

double temp3 = temperatureConverter1.CelsiusToFahrenheit(6000);

double temp4 = temperatureConverter1.FahrenheitToCelsius(-1000);