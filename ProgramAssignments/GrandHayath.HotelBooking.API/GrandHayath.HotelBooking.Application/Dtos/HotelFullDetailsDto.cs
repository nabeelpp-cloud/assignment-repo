using GrandHayath.HotelBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.Dtos
{
    public class HotelFullDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public double Rating { get; set; }
        public double StarRating { get; set; }
        public decimal MinimumPrice { get; set; }
        public decimal MaximumPrice { get; set; }
        public ICollection<HotelImagesDto> HotelImages { get; set; } = new List<HotelImagesDto>();
        public ICollection<RoomDto> Rooms { get; set; } = new List<RoomDto>();
        public ICollection<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    }
}
