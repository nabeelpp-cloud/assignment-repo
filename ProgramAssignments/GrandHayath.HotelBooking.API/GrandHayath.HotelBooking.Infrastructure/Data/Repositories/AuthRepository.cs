using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace GrandHayath.HotelBooking.Infrastructure.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IApplicationDbContext _context;

        public AuthRepository(IApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Employee?> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.RefreshToken == refreshToken);
        }

        public async Task SaveRefreshTokenAsync(Employee user, string refreshToken)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime= DateTime.UtcNow.AddDays(15);
            await _context.SaveChangesAsync();
        }

        public bool VerifyPassword(Employee user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password,user.PasswordHash);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
