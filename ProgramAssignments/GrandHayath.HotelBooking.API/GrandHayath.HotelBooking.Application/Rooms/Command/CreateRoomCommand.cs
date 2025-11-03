using GrandHayath.HotelBooking.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.Rooms.Command
{
    public class CreateRoomCommand : IRequest<int>
    {
        public string RoomNumber { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public RoomStatus Status { get; set; }
        public decimal PricePerNight { get; set; }

    }
}
