using MediatR;

namespace GrandHayath.HotelBooking.Application.Employees.Command
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

}
