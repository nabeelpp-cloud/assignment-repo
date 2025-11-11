using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.Dtos
{
    public class HotelWithRoomsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RoomDto> Rooms { get; set; }
    }
}
