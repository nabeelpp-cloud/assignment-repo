using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Payments.Command
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, int>
    {
        private readonly IPaymentRepository repository;
        public DeletePaymentCommandHandler(IPaymentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            return await repository.DeleteAsync(request.Id);
        }
    }
}
