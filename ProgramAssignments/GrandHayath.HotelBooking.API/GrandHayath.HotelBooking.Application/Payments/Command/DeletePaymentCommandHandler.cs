using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Payments.Command
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, int>
    {
        private readonly IPaymentRepository _repository;
        public DeletePaymentCommandHandler(IPaymentRepository _repository)
        {
            this._repository = _repository;
        }
        public async Task<int> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _repository.GetByIdAsync(request.Id);
            if (payment == null)
            {
                return 0;
            }

            return await _repository.DeleteAsync(payment);
        }
    }
}
