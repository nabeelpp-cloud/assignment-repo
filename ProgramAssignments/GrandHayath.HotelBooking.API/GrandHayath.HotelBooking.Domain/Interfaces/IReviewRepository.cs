using GrandHayath.HotelBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Domain.Interfaces
{
    public interface IReviewRepository
    {
        Task<int> AddAsync(Review review);
        Task<List<Review>> GetAllAsync();
        Task<Review?> GetByIdAsync(int id);
        Task<int> DeleteAsync(Review review);
        Task<int> UpdateAsync(Review review);
    }
}
