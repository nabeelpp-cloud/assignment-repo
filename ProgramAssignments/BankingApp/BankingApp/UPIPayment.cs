using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal class UPIPayment : IPaymentService
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Paid {amount} using UPI Payment");
        }
    }
}
