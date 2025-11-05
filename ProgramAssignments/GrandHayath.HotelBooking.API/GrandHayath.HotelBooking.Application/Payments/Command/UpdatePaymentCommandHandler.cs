using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Payments.Command
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, int>
    {
        private readonly IPaymentRepository repository;
        public UpdatePaymentCommandHandler(IPaymentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new Payment
            {
                Id = request.Id,
                BookingId = request.BookingId,
                PaymentDate = request.PaymentDate,
                Amount = request.Amount,
                Method = request.Method,
                Status = request.Status
            };
            return await repository.UpdateAsync(request.Id,payment);
        }
    }
}
