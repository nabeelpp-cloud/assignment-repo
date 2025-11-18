using GrandHayath.HotelBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.Dtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public string? HotelName { get; set; }
        public string? HotelAddress { get; set; }
        public string? RoomType { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
