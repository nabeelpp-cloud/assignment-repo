using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Bookings.Command
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, int>
    {
        private readonly IBookingRepository _repository;
        public DeleteBookingCommandHandler(IBookingRepository _repository)
        {
            this._repository = _repository;
        }
        public async Task<int> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _repository.GetByIdAsync(request.Id);
            if (booking == null)
            {
                return 0;
            }

            return await _repository.DeleteAsync(booking);
        }
    }
}
