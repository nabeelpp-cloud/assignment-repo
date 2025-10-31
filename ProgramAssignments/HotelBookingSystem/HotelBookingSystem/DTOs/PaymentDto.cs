using HotelBookingSystem.Models;

namespace HotelBookingSystem.DTOs
{
    public class PaymentDto
    {

        public int BookingId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }

    }
    public enum PaymentStatus
    {
        Pending,
        Paid,
        Failed
    }
    public enum PaymentMethod
    {
        Cash,
        Card,
        UPI,
        Online
    }

}
