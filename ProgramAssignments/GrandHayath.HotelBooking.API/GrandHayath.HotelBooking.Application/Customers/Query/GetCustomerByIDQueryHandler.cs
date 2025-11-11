using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Customers.Query
{
    public class GetCustomerByIDQueryHandler : IRequestHandler<GetCustomerByIDQuery, CustomerDto?> 
    {
        private readonly IApplicationDbContext dbContext;

        public GetCustomerByIDQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CustomerDto?> Handle(GetCustomerByIDQuery request, CancellationToken cancellationToken)
        {
            var customer =await dbContext.Customers.FindAsync(request.Id);
            if (customer != null)
            {
                var customerDto = new CustomerDto
                {
                    
                    FullName = customer.FullName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    IdProofNumber = customer.IdProofNumber,
                };
                return customerDto;
            }
            return null;
        }
    }
}
