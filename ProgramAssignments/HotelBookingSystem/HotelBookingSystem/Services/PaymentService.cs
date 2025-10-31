using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services
{
    public interface IPaymentService
    {
        public Task<string> CreatePayment(Payment payment);
        public Task<string> UpdatePayment(int id, PaymentDto paymentDto);
        public Task<string> RemovePayment(int id);
        public Task<Payment> GetPayment(int id);
        public Task<List<Payment>> GetAllPayments();
    }

    public class PaymentService : IPaymentService
    {
        private readonly HotelManagementDbContext _context;

        public PaymentService(HotelManagementDbContext hotelManagementDbContext)
        {
            _context = hotelManagementDbContext;
        }

        public async Task<string> CreatePayment(Payment payment)
        {
            _context.Payments.Add(payment);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Payment created successfully";

            return "Error creating payment";
        }

        public async Task<string> UpdatePayment(int id, PaymentDto paymentDto)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);
            if (payment == null)
                return "Payment not found";

            if (paymentDto.BookingId != 0 && paymentDto.BookingId != payment.BookingId)
                payment.BookingId = paymentDto.BookingId;

            if (paymentDto.PaymentDate != default && paymentDto.PaymentDate != payment.PaymentDate)
                payment.PaymentDate = paymentDto.PaymentDate;

            if (paymentDto.Amount > 0 && paymentDto.Amount != payment.Amount)
                payment.Amount = paymentDto.Amount;

            if (paymentDto.Method.HasValue && paymentDto.Method.Value != payment.Method)
                payment.Method = paymentDto.Method.Value;

            
            if (paymentDto.Method.HasValue && !paymentDto.Method.Value.Equals(payment.Method))
                payment.Status = paymentDto.Status;

            int result = await _context.SaveChangesAsync();
            if (result > 0)
                return "Payment updated successfully";

            return "Error updating payment";
        }

        public async Task<string> RemovePayment(int id)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);
            if (payment == null)
                return "Payment not found";

            _context.Payments.Remove(payment);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
                return "Payment deleted successfully";

            return "Error deleting payment";
        }

        public async Task<Payment> GetPayment(int id)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Payment>> GetAllPayments()
        {
            return await _context.Payments.ToListAsync();
        }
    }
}
