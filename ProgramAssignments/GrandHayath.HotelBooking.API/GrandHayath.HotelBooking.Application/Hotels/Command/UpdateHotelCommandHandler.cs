using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Hotels.Command
{
    public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, int>
    {
        private readonly IHotelRepository hotelRepository;

        public UpdateHotelCommandHandler(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public async Task<int> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            Hotel hotel = new Hotel();
            hotel.Name = request.Name;
            hotel.Address = request.Address;
            hotel.City = request.City;
            hotel.Country = request.Country;
            hotel.PhoneNumber = request.PhoneNumber;

            return await hotelRepository.UpdateAsync(request.Id,hotel);
        }
    }
}
