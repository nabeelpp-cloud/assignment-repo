using GrandHayath.HotelBooking.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetHotelFullDetailsByIdQuery : IRequest<HotelFullDetailsDto>
    {
        public int Id { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }

    }
}
