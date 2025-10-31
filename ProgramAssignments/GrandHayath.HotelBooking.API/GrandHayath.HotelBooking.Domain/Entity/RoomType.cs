using System.Diagnostics.CodeAnalysis;

namespace GrandHayath.HotelBooking.Domain.Entity
{
    public class RoomType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int Capacity {  get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
       
    }
}
