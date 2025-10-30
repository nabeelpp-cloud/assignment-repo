﻿using System.Diagnostics.CodeAnalysis;

namespace HotelBookingSystem.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int Capacity {  get; set; }
        [AllowNull]
        public ICollection<Room> Rooms { get; set; }
       
    }
}
