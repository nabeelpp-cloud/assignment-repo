using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    
    public interface IBoookingService
    {
        public string CreateBooking(Booking booking);
        public string UpdateBooking(int id, int? customerId, int? roomId, DateTime? checkInDate, DateTime? checkOutDate, decimal? totalAmount);
        public string RemoveBooking(int id);
        public Booking GetBooking(int id);
        public List<Booking> GetAllBookings();
    }
    public class BookingService : IBoookingService
    {
        private readonly HotelManagementDbContext _context;
        public BookingService(HotelManagementDbContext hotelManagementDbContext)
        {
            _context = hotelManagementDbContext;
        }
        public string CreateBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            int resp=_context.SaveChanges();
            if (resp == 0)
                return null;
            return "New booking created succesfully";
        }

        public List<Booking> GetAllBookings()
        {
            var resp=_context.Bookings.ToList();
            return resp;
        }

        public Booking GetBooking(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.Id == id);
            return booking;
        }

        public string RemoveBooking(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.Id == id);
            if (booking != null)
            {
                _context.Remove(booking);
                var resp = _context.SaveChanges();
                if (resp != null)
                {
                    return "Booking Deleted Successfully";
                }
                return "Error deleting booking";
            }
            return "Booking NotFound";
        }

        public string UpdateBooking(int id, int? customerId, int? roomId, DateTime? checkInDate, DateTime? checkOutDate, decimal? totalAmount)
        {
            var booking= _context.Bookings.FirstOrDefault(x=>x.Id==id);
            if (booking == null)
                return "Booking NotFound";
            if (customerId.HasValue)
                booking.CustomerId = customerId.Value;

            if (roomId.HasValue)
                booking.RoomId = roomId.Value;

            if (checkInDate.HasValue)
                booking.CheckInDate = checkInDate.Value;

            if (checkOutDate.HasValue)
                booking.CheckOutDate = checkOutDate.Value;

            if (totalAmount.HasValue)
                booking.TotalAmount = totalAmount.Value;

            var resp=_context.SaveChanges();
            if(resp>0)
            {
                return "Updated succesfully";
            }
            return "Error updating booking";
        }
    }
}
