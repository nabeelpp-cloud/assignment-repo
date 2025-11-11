using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Hotels.Query
{
    public class GetHotelWithEmployeesQueryHandler : IRequestHandler<GetHotelWithEmployeesQuery, HotelWithEmployeesDto?>
    {
        private readonly IApplicationDbContext _context;

        public GetHotelWithEmployeesQueryHandler(IApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<HotelWithEmployeesDto?> Handle(GetHotelWithEmployeesQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _context.Hotels
                .Include(h => h.Employees)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            HotelWithEmployeesDto hotelWithEmployeesDto = new HotelWithEmployeesDto();
            if (hotel != null) 
            {
                hotelWithEmployeesDto.Id=hotel.Id;
                hotelWithEmployeesDto.Name=hotel.Name;
                List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
                foreach (var employee in hotel.Employees)
                {
                    employeeDtos.Add(new EmployeeDto
                    {
                        HotelId = employee.HotelId,
                        FullName = employee.FullName,
                        Role = employee.Role,
                        Email = employee.Email
                    });
                }
                hotelWithEmployeesDto.Employees = employeeDtos;
                return hotelWithEmployeesDto;
            }
            return null;
        }
    }

}
