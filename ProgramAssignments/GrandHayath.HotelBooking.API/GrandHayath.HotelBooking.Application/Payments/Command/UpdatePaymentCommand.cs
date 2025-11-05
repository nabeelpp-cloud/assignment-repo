using GrandHayath.HotelBooking.Domain.Entity;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Payments.Command
{
    public class UpdatePaymentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
