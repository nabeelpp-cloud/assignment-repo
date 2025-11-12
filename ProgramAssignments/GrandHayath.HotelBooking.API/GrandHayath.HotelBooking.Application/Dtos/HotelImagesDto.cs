using GrandHayath.HotelBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.Dtos
{
    public class HotelImagesDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int HotelId { get; set; }
    }
}
