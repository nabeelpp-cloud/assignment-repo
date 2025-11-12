using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Domain.Entity
{
    public class HotelImages
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
