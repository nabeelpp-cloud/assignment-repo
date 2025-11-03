using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{

    public interface IBoookingService
    {
        public string CreateBooking(Booking booking);
        public string UpdateBooking(int id, BookingDto bookingDto);
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
            int resp = _context.SaveChanges();
            if (resp == 0)
                return null;
            return "New booking created succesfully";
        }

        public List<Booking> GetAllBookings()
        {
            var resp = _context.Bookings.ToList();
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

        public string UpdateBooking(int id, BookingDto bookingDto)
        {
            var exsistingBooking = _context.Bookings.FirstOrDefault(x => x.Id == id);
            if (exsistingBooking == null)
                return "Booking NotFound";
            if (bookingDto.CustomerId != 0 && bookingDto.CustomerId != exsistingBooking.CustomerId)
                exsistingBooking.CustomerId = bookingDto.CustomerId;

            if (bookingDto.RoomId != 0 && bookingDto.RoomId != exsistingBooking.RoomId)
                exsistingBooking.RoomId = bookingDto.RoomId;

            if (bookingDto.CheckInDate != default && bookingDto.CheckInDate != exsistingBooking.CheckInDate)
                exsistingBooking.CheckInDate = bookingDto.CheckInDate;

            if (bookingDto.CheckOutDate != default && bookingDto.CheckOutDate != exsistingBooking.CheckOutDate)
                exsistingBooking.CheckOutDate = bookingDto.CheckOutDate;

            if (bookingDto.TotalAmount != 0 && bookingDto.TotalAmount != exsistingBooking.TotalAmount)
                exsistingBooking.TotalAmount = bookingDto.TotalAmount;
            var resp = _context.SaveChanges();
            if (resp > 0)
            {
                return "Updated succesfully";
            }
            return "Error updating booking";
        }
    }
}
