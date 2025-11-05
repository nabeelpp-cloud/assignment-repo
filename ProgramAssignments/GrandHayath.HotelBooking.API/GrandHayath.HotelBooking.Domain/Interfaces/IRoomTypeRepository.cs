using GrandHayath.HotelBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Domain.Interfaces
{
    public interface IRoomTypeRepository
    {
        Task<int> AddAsync(RoomType roomType);
        Task<List<RoomType>> GetAllAsync();
        Task<RoomType?> GetByIdAsync(int id);

        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(int id,RoomType roomType);
    }
}
