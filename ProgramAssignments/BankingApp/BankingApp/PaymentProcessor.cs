using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class PaymentProcessor
    {
        private readonly IPaymentService _paymentService;
        public PaymentProcessor(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public void ProcessPayment(double amount)
        {
            _paymentService.MakePayment(amount);
        }
    }
}
