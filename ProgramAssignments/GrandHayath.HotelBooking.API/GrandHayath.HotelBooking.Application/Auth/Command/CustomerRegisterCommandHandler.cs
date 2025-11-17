using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Auth.Command
{
    public class CustomerRegisterCommandHandler : IRequestHandler<CustomerRegisterCommand, LoginResponseDto>
    {
        private readonly ICustomerAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public CustomerRegisterCommandHandler(ICustomerAuthRepository authRepository, IJwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }
        public async Task<LoginResponseDto> Handle(CustomerRegisterCommand request, CancellationToken cancellationToken)
        {
            if (await _authRepository.CheckEmailExistsAsync(request.Email)) 
            {
                throw new Exception("Email already in use");
            }

            var passwordHash = _authRepository.HashPassword(request.Password);

            var newCustomer = new Customer
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                IdProofNumber = request.IdProofNumber,
                PasswordHash = passwordHash
            };

            await _authRepository.AddCustomerAsync(newCustomer);

            var accessToken = _jwtService.GenerateToken(newCustomer.Id, newCustomer.Email, "Customer");
            var refreshToken = _jwtService.GenerateRefreshToken();

            await _authRepository.SaveRefreshTokenAsync(newCustomer, refreshToken);

            return new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(30),
                Role = "Customer",
                Email = newCustomer.Email
            };
        }
    }
}
