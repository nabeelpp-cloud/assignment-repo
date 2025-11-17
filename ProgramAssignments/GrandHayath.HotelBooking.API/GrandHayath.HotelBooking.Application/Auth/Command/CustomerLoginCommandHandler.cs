using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Auth.Command
{
    public class CustomerLoginCommandHandler : IRequestHandler<CustomerLoginCommand, LoginResponseDto> 
    {
        private readonly ICustomerAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public CustomerLoginCommandHandler(ICustomerAuthRepository authRepository,IJwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseDto> Handle(CustomerLoginCommand request, CancellationToken cancellationToken)
        {
            var customer
                = await _authRepository.GetByEmailAsync(request.Email);
            if (customer == null)
                throw new Exception("Invalid email or password");

            bool isPasswordValid = _authRepository.VerifyPassword(customer, request.Password);
            if (!isPasswordValid)
                throw new Exception("Invalid email or password");

            var accessToken = _jwtService.GenerateToken(customer.Id, customer.Email, "Customer");
            var refreshToken = _jwtService.GenerateRefreshToken();

            await _authRepository.SaveRefreshTokenAsync(customer, refreshToken);

            return new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(30),
                Role = "Customer",
                Email = customer.Email
            };
        }
    }
}
