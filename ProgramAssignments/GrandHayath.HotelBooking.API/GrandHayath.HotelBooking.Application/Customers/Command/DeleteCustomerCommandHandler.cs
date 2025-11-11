using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Customers.Command
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int>
    {
        private readonly ICustomerRepository _repository;

        public DeleteCustomerCommandHandler(ICustomerRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id);
            if (customer == null)
            {
                return 0;
            }

            return await _repository.DeleteAsync(customer);
        }

    }
}
