using MediatR;

namespace GrandHayath.HotelBooking.Application.Payments.Command
{
    public class DeletePaymentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
