using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Auth.Command
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand,Unit>
    {
        private readonly IAuthRepository _authRepository;

        public LogoutCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {

            var employee = await _authRepository.GetByRefreshTokenAsync(request.RefreshToken);

            if (employee != null)
            {
                employee.RefreshToken = null;
                employee.RefreshTokenExpiryTime = null;

                await _authRepository.SaveChangesAsync(); 
            }

            return Unit.Value;
        }
    }

}
