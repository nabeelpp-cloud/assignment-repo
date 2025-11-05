using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Customers.Query
{
    public class GetCustomerByIDQuery : IRequest<CustomerDto?> 
    {
        public int Id { get; set; }
    }
}
