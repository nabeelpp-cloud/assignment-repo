using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Infrastructure.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IApplicationDbContext dbContext;

        public PaymentRepository(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> AddAsync(Payment payment)
        {
            await dbContext.Payments.AddAsync(payment);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var payment =await dbContext.Payments.FindAsync(id);
            if(payment != null)
            {
                dbContext.Payments.Remove(payment);
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            var payments =await dbContext.Payments.ToListAsync();
            return payments;
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            var payment =await dbContext.Payments.FindAsync(id);
            return payment;
        }

        public async Task<int> UpdateAsync(int id, Payment payment)
        {
            var existingPayment =await  dbContext.Payments.FindAsync(id);
            if (existingPayment != null) 
            {
                existingPayment.BookingId = payment.BookingId;
                existingPayment.Amount = payment.Amount;
                existingPayment.PaymentDate = payment.PaymentDate;
                existingPayment.Method = payment.Method;
                existingPayment.Status = payment.Status;
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
