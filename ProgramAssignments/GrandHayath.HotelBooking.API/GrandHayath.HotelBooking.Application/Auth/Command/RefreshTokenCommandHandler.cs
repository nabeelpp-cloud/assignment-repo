using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Auth.Command
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, LoginResponseDto>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public RefreshTokenCommandHandler(IAuthRepository authRepository, IJwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var employee = await _authRepository.GetByRefreshTokenAsync(request.RefreshToken);
            if (employee == null || employee.RefreshTokenExpiryTime <= DateTime.UtcNow)
                throw new UnauthorizedAccessException("Invalid or expired refresh token");

            var newAccessToken = _jwtService.GenerateToken(employee.Id, employee.Email, employee.Role);
            var newRefreshToken = _jwtService.GenerateRefreshToken();

            await _authRepository.SaveRefreshTokenAsync(employee, newRefreshToken);

            return new LoginResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(30),
                Role = employee.Role,
                Email = employee.Email
            };
        }
    }
}
