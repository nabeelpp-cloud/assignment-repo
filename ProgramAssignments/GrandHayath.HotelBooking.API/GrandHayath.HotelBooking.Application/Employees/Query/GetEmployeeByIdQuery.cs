using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Employees.Query
{
    public class GetEmployeeByIdQuery :IRequest<EmployeeDto>
    {
        public int Id { get; set; }
    }
}
