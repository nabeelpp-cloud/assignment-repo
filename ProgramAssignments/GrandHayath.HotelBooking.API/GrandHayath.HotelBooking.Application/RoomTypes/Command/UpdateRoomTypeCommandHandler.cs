using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Command
{
    public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, int>
    {
        private readonly IRoomTypeRepository _repository;

        public UpdateRoomTypeCommandHandler(IRoomTypeRepository repository)
        {
            this._repository = repository;
        }
        public async Task<int> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var existingRoomType = await _repository.GetByIdAsync(request.Id);

            if (existingRoomType == null)
            {
                return 0;
            }

            existingRoomType.TypeName = request.TypeName;
            existingRoomType.Description = request.Description;
            existingRoomType.Capacity = request.Capacity;
   

            return await _repository.UpdateAsync(existingRoomType);
            
        }
    }
}
