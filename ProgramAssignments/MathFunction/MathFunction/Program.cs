// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using MathUtilities;

MathClass m1 = new MathClass();

Console.Write("Enetr a number : ");
int number=int.Parse(Console.ReadLine());

if (m1.IsEven(number))
{
    Console.WriteLine("The number is even");
}
else
{
    Console.WriteLine("The number is odd");
}

if(m1.IsPrime(number))
{
    Console.WriteLine("The number is Prime");
}
else
{
    Console.WriteLine("The number is not prime");
}
Console.WriteLine($"Factorial of this number : {m1.Factorial(number)}");