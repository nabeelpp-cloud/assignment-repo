using GrandHayath.HotelBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Domain.Interfaces
{
    public  interface IPaymentRepository
    {
        Task<int> AddAsync(Payment payment);
        Task<List<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);

        Task<int> DeleteAsync(Payment payment);
        Task<int> UpdateAsync(Payment payment);
    }
}
