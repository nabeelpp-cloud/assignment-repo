using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Application.Hotels.Command
{
    public class DeleteHotelCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
