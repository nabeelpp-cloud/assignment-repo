using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Payments.Command
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
    {
        private readonly IPaymentRepository repository;

        public CreatePaymentCommandHandler(IPaymentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new Payment
            {
                BookingId = request.BookingId,
                PaymentDate = request.PaymentDate,
                Amount = request.Amount,
                Method = request.Method,
                Status = request.Status
            };
            return await repository.AddAsync(payment);
        }
    }
}
