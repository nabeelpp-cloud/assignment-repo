using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public interface IPaymentService
    {
        string CreatePayment(Payment payment);
        string UpdatePayment(int id, int? bookingId, DateTime? paymentDate, decimal? amount, PaymentMethod? method, PaymentStatus? status);
        string RemovePayment(int id);
        Payment GetPayment(int id);
        List<Payment> GetAllPayments();
    }

    public class PaymentService : IPaymentService
    {
        private readonly HotelManagementDbContext _context;

        public PaymentService(HotelManagementDbContext hotelManagementDbContext)
        {
            _context = hotelManagementDbContext;
        }

        public string CreatePayment(Payment payment)
        {
            _context.Payments.Add(payment);
            int result = _context.SaveChanges();

            if (result > 0)
                return "Payment created successfully";

            return "Error creating payment";
        }

        public string UpdatePayment(int id, int? bookingId, DateTime? paymentDate, decimal? amount, PaymentMethod? method, PaymentStatus? status)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.Id == id);
            if (payment == null)
                return "Payment not found";

            if (bookingId.HasValue)
                payment.BookingId = bookingId.Value;

            if (paymentDate.HasValue)
                payment.PaymentDate = paymentDate.Value;

            if (amount.HasValue)
                payment.Amount = amount.Value;

            if (method.HasValue)
                payment.Method = method.Value;

            if (status.HasValue)
                payment.Status = status.Value;

            int result = _context.SaveChanges();
            if (result > 0)
                return "Payment updated successfully";

            return "Error updating payment";
        }

        public string RemovePayment(int id)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.Id == id);
            if (payment == null)
                return "Payment not found";

            _context.Payments.Remove(payment);
            int result = _context.SaveChanges();

            if (result > 0)
                return "Payment deleted successfully";

            return "Error deleting payment";
        }

        public Payment GetPayment(int id)
        {
            return _context.Payments.FirstOrDefault(p => p.Id == id);
        }

        public List<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }
    }
}
