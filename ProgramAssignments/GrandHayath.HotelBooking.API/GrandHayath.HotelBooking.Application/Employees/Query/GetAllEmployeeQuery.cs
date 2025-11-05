using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.Employees.Query
{
    public class GetAllEmployeeQuery : IRequest<List<EmployeeDto>>
    {

    }
}
