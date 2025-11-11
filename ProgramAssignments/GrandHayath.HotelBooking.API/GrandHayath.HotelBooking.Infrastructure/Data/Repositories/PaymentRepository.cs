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
        private readonly IApplicationDbContext _context;

        public PaymentRepository(IApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<int> AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Payment payment)
        {

            _context.Payments.Remove(payment);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task<int> UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            return await _context.SaveChangesAsync();
        }
    }
}
