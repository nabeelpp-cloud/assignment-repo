using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace GrandHayath.HotelBooking.Infrastructure.Data.Repositories
{
    public class CustomerAuthRepository : ICustomerAuthRepository
    {
        private readonly IApplicationDbContext _context;

        public CustomerAuthRepository(IApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Customer?> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Customers.FirstOrDefaultAsync(e => e.RefreshToken == refreshToken);
        }

        public async Task SaveRefreshTokenAsync(Customer user, string refreshToken)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime= DateTime.UtcNow.AddDays(15);
            await _context.SaveChangesAsync();
        }

        public bool VerifyPassword(Customer user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password,user.PasswordHash);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            return await _context.Customers.AnyAsync(c => c.Email == email);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }
    }
}
