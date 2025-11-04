using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal class NetBankingPayment : IPaymentService
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Paid {amount} using Net Banking");

        }
    }
}
