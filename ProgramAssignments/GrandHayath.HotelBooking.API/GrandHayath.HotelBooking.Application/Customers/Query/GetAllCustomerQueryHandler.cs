using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Customers.Query
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerDto>>
    {
        private readonly IApplicationDbContext dbContext;

        public GetAllCustomerQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<CustomerDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = dbContext.Customers.ToList();
            List<CustomerDto> customerDtos = new List<CustomerDto>();
            foreach (var customer in customers) 
            {

                var customerDto = new CustomerDto
                {
                    FullName = customer.FullName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    IdProofNumber = customer.IdProofNumber,
                };
                customerDtos.Add(customerDto);
            }
            return customerDtos;
        }
    }
}
