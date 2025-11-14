// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using MathLibrary;

SimpleProblem simpleProblem= new SimpleProblem();

Console.Write("Enter first number : ");
int num1=int.Parse(Console.ReadLine());
Console.Write("Enter second number  : ");
int num2=int.Parse(Console.ReadLine());

Console.Write("Choose operation ( + , - , * , / , %) : ");
char operation = char.Parse(Console.ReadLine());


    switch (operation)
    {
        case '+' : simpleProblem.Addition(num1, num2);
            break;
        case '-' : simpleProblem.Subtraction(num1, num2);
            break;
        case '*' : simpleProblem.Multiplication(num1, num2);
            break;
        case '/' : simpleProblem.Division(num1, num2);
            break;
        case '%' :simpleProblem.Modulus(num1, num2);
            break;
        default: Console.WriteLine("Wrong operation");
            break;
    }
