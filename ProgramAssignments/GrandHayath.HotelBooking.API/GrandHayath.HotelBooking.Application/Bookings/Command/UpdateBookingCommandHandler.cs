using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Bookings.Command
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, int>
    {
        private readonly IBookingRepository _repository;
        public UpdateBookingCommandHandler(IBookingRepository repository)
        {
            this._repository = repository;
        }
        public async Task<int> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var existingBooking = await _repository.GetByIdAsync(request.Id);

            if (existingBooking == null)
            {
                return 0;
            }

            existingBooking.CustomerId = request.CustomerId;
            existingBooking.RoomId = request.RoomId;
            existingBooking.CheckInDate = request.CheckInDate;
            existingBooking.CheckOutDate = request.CheckOutDate;
            existingBooking.TotalAmount = request.TotalAmount;

            return await _repository.UpdateAsync(existingBooking);
        }
    }
}
