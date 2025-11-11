using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Customers.Command
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly ICustomerRepository _repository;

        public UpdateCustomerCommandHandler(ICustomerRepository repository)
        {
            this._repository = repository;
        }
        public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var existingCustomer = await _repository.GetByIdAsync(request.Id);

            if (existingCustomer == null)
            {
                return 0;
            }

            existingCustomer.FullName = request.FullName;
            existingCustomer.Email = request.Email;
            existingCustomer.PhoneNumber = request.PhoneNumber;
            existingCustomer.IdProofNumber = request.IdProofNumber;

            return await _repository.UpdateAsync(existingCustomer);
        }
    }
}
