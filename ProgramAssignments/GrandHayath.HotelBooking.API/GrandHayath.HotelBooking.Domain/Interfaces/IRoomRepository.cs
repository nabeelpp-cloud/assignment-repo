using GrandHayath.HotelBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Domain.Interfaces
{
    public interface IRoomRepository
    {
        Task<int> AddAsync(Room room);
        Task<List<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(int id);

        Task<int> DeleteAsync(Room room);
        Task<int> UpdateAsync(Room room);

    }
}
