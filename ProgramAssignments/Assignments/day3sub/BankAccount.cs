using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.day3sub
{
    public class BankAccount
    {
        public int AccountNumber;
        public string AccountName;
        public double AccountBalance;
        public BankAccount() 
        {
            Console.WriteLine("Welcome to Your Bank Account");
        }
        public BankAccount(int AccNo) :this()
        { 
            AccountNumber = AccNo;
        }
        public BankAccount(int AccNo,string AccName) : this(AccNo) 
        {
            AccountName = AccName;
        }
        public BankAccount(int AccNo, string AccName, double Balance) : this(AccNo, AccName) 
        { 
            AccountBalance = Balance;
        }
        public void Deposite(double amount)
        {
            Console.WriteLine($"Deposited Amount: {amount}");
            AccountBalance += amount;
        }
        public void ViewBalance()
        {
            Console.WriteLine($"Account Number: {AccountNumber}, Account Name: {AccountName}, Account Balance: {AccountBalance}");
        }
    }
}
