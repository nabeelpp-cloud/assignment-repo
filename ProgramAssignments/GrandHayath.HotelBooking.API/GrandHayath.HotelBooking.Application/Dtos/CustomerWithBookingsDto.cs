using GrandHayath.HotelBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.Dtos
{
    public class CustomerWithBookingsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<BookingDto> Bookings { get; set; } = new List<BookingDto>();


    }
}
