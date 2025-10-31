using System.ComponentModel.DataAnnotations.Schema;

namespace GrandHayath.HotelBooking.Domain.Entity
{
    public class Payment

    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public DateTime PaymentDate { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
        public Booking Booking { get; set; }

    }
    public enum PaymentStatus 
    { 
        Pending, 
        Paid, 
        Failed 
    }
    public enum PaymentMethod { 
        Cash, 
        Card, 
        UPI, 
        Online 
    }
}
