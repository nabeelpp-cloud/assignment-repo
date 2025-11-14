using GrandHayath.HotelBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<Employee?> GetByEmailAsync(string email);
        bool VerifyPassword(Employee user, string password);
        Task SaveRefreshTokenAsync(Employee user, string refreshToken);
        Task<Employee?> GetByRefreshTokenAsync(string refreshToken);
        Task SaveChangesAsync();

    }
}
