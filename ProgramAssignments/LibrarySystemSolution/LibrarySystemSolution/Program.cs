// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using BusinessLogic;

Console.WriteLine("This is the Expense manager");

DataProcessor dataProcessor=new DataProcessor();
int totalExpense = dataProcessor.ShowTotalExpense();
Console.WriteLine($"Total Expense : {totalExpense}");