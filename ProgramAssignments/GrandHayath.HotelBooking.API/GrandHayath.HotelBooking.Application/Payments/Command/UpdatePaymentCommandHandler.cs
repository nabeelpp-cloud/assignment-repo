using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Payments.Command
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, int>
    {
        private readonly IPaymentRepository _repository;
        public UpdatePaymentCommandHandler(IPaymentRepository repository)
        {
            this._repository = repository;
        }
        public async Task<int> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var existingPayment = await _repository.GetByIdAsync(request.Id);

            if (existingPayment == null)
            {
                return 0;
            }

            existingPayment.BookingId = request.BookingId;
            existingPayment.PaymentDate = request.PaymentDate;
            existingPayment.Amount = request.Amount;
            existingPayment.Method = request.Method;
            existingPayment.Status = request.Status;

            return await _repository.UpdateAsync(existingPayment);

        }
    }
}
