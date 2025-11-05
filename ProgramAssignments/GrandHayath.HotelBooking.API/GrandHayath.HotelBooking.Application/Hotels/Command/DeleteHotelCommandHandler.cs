using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Hotels.Command
{
    public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, int>
    {
        private readonly IHotelRepository hotelRepository;

        public DeleteHotelCommandHandler(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public async Task<int> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
        {
            return await hotelRepository.DeleteAsync(request.Id);
        }
    }
}
