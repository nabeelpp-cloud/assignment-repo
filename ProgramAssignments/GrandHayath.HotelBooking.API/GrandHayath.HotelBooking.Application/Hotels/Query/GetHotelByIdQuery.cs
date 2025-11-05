using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetHotelByIdQuery : IRequest<HotelDto?>
    {
        public int Id { get; set; }
    }
}
