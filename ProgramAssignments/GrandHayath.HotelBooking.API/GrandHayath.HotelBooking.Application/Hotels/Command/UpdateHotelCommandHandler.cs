using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Hotels.Command
{
    public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, int>
    {
        private readonly IHotelRepository _repository;

        public UpdateHotelCommandHandler(IHotelRepository hotelRepository)
        {
            this._repository = hotelRepository;
        }

        public async Task<int> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            var existingHotel = await _repository.GetByIdAsync(request.Id);

            if (existingHotel == null)
            {
                return 0;
            }

            existingHotel.Name = request.Name;
            existingHotel.Address = request.Address;
            existingHotel.City = request.City;
            existingHotel.Country = request.Country;
            existingHotel.PhoneNumber = request.PhoneNumber;

            return await _repository.UpdateAsync(existingHotel);
        }
    }
}
