using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Bookings.Command
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, int>
    {
        private readonly IBookingRepository repository;
        public DeleteBookingCommandHandler(IBookingRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            return await repository.DeleteAsync(request.Id);
        }
    }
}
