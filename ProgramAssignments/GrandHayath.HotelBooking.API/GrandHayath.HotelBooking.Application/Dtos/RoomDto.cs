using GrandHayath.HotelBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.Dtos
{
    public class RoomDto
    {
        public string RoomNumber { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public RoomStatus Status { get; set; }
        public decimal PricePerNight { get; set; }
    }
}
