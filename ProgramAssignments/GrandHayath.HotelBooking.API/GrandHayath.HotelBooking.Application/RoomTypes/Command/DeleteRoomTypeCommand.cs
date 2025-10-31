using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.RoomTypes.Command
{
    public class DeleteRoomTypeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
