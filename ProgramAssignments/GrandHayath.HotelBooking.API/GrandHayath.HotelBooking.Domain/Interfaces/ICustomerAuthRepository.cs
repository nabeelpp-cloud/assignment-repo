using GrandHayath.HotelBooking.Domain.Entity;

namespace GrandHayath.HotelBooking.Domain.Interfaces
{
    public interface ICustomerAuthRepository
    {
        Task<Customer?> GetByEmailAsync(string email);
        bool VerifyPassword(Customer user, string password);
        Task SaveRefreshTokenAsync(Customer user, string refreshToken);
        Task<Customer?> GetByRefreshTokenAsync(string refreshToken);
        Task SaveChangesAsync();

        Task<bool> CheckEmailExistsAsync(string email);
        string HashPassword(string password);
        Task AddCustomerAsync(Customer customer);

    }
}
