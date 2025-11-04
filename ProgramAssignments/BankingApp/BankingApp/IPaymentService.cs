using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public interface IPaymentService
    {
        public void MakePayment(double amount);
    }
}
