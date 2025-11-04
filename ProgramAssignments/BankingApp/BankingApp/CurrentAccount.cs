using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class CurrentAccount : IAccount
    {

        private double _balance = 0;
        public void Deposit(double amount)
        {
            _balance += amount;
            Console.WriteLine($"Deposited {amount} to your Current Account Balance is : {_balance}");
        }

        public double GetBalance()
        {
            return _balance;
        }

        public void Withdraw(double amount)
        {
            if (amount < _balance)
            {
                _balance -= amount;
                Console.WriteLine($"Withdrawed {amount} from your Current Account Balance : {_balance}");
            }
            else
            {
                Console.WriteLine("Insufficent balance");
            }
        }
    }

}
