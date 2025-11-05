using MediatR;

namespace GrandHayath.HotelBooking.Application.Employees.Command
{
    public class UpdateEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }

}
