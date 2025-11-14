using System.Security.Claims;

namespace GrandHayath.HotelBooking.Domain.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(int employeeId, string email, string role);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
