using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Auth.Command
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto> 
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(IAuthRepository authRepository,IJwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var employee = await _authRepository.GetByEmailAsync(request.Email);
            if (employee == null)
                throw new Exception("Invalid email or password");

            bool isPasswordValid = _authRepository.VerifyPassword(employee, request.Password);
            if (!isPasswordValid)
                throw new Exception("Invalid email or password");

            var accessToken = _jwtService.GenerateToken(employee.Id, employee.Email, employee.Role);
            var refreshToken = _jwtService.GenerateRefreshToken();

            await _authRepository.SaveRefreshTokenAsync(employee, refreshToken);

            return new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(30),
                Role = employee.Role,
                Email = employee.Email
            };
        }
    }
}
