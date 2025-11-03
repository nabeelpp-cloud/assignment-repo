using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Hotels.Command
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, int> 
    {
        private readonly ApplicationDbContext context;

        public CreateHotelCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            Hotel hotel = new Hotel();
            hotel.Name = request.Name;
            hotel.Address = request.Address;
            hotel.City = request.City;
            hotel.Country = request.Country;
            hotel.PhoneNumber = request.PhoneNumber;
            try
            {
                await context.Hotels.AddAsync(hotel);
                var response = await context.SaveChangesAsync();
                return response;
            }
            catch (Exception ex) 
            {
                return 0;
            }
        }
    }
}
