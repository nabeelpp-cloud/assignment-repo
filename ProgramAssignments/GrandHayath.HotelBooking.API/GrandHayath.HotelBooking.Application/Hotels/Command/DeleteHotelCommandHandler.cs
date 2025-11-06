using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Hotels.Command
{
    public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, int>
    {
        private readonly IHotelRepository _repository;

        public DeleteHotelCommandHandler(IHotelRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<int> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _repository.GetByIdAsync(request.Id);
            if (hotel == null)
            {
                return 0;
            }

            return await _repository.DeleteAsync(hotel);
        }
    }
}
