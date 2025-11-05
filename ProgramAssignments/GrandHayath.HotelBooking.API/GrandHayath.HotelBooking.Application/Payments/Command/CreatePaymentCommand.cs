using GrandHayath.HotelBooking.Domain.Entity;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrandHayath.HotelBooking.Application.Payments.Command
{
    public class CreatePaymentCommand : IRequest<int>
    {
        public int BookingId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
