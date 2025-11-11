using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.Customers.Query
{
    public class GetCustomerWithBookingsQuery : IRequest<CustomerWithBookingsDto>
    {
        public int Id {  get; set; }
    }
}
