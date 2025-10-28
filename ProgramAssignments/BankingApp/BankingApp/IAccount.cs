using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public interface IAccount
    {
        public void Deposit(double amount);
        public void Withdraw(double amount);
        public double GetBalance();
    }
}
