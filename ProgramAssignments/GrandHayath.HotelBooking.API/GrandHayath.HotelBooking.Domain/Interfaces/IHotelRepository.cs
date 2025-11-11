using GrandHayath.HotelBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Domain.Interfaces
{
    public interface IHotelRepository
    {
        Task<int> AddAsync(Hotel hotel);
        Task<List<Hotel>> GetAllAsync();
        Task<Hotel?> GetByIdAsync(int id);

        Task<int> DeleteAsync(Hotel hotel);
        Task<int> UpdateAsync(Hotel hotel);
    }
}
