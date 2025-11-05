using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Hotels.Command
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, int> 
    {
        private readonly IHotelRepository hotelRepository;

        public CreateHotelCommandHandler(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public async Task<int> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            Hotel hotel = new Hotel();
            hotel.Name = request.Name;
            hotel.Address = request.Address;
            hotel.City = request.City;
            hotel.Country = request.Country;
            hotel.PhoneNumber = request.PhoneNumber;
            
            return await hotelRepository.AddAsync(hotel);
        }
    }
}
