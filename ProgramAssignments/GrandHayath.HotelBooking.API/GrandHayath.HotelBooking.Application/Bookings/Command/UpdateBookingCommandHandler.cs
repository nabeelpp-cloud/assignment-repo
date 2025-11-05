using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Bookings.Command
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, int>
    {
        private readonly IBookingRepository repository;
        public UpdateBookingCommandHandler(IBookingRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new Booking
            {
                CustomerId = request.CustomerId,
                RoomId = request.RoomId,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate,
                TotalAmount = request.TotalAmount
            };
            return await repository.UpdateAsync(request.Id, booking);
        }
    }
}
