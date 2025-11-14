using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.Auth.Command
{
    public class LogoutCommand : IRequest<Unit>
    {
        public string RefreshToken { get; set; } = string.Empty;
    }

}
