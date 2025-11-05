using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrandHayath.HotelBooking.Application.Employees.Query
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, List<EmployeeDto>>
    {
        private readonly IApplicationDbContext dbContext;

        public GetAllEmployeeQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<EmployeeDto>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employees =await dbContext.Employees.ToListAsync(cancellationToken);
            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
            foreach (var emp in employees)
            {
                employeeDtos.Add(new EmployeeDto
                {
                    HotelId = emp.HotelId,
                    FullName = emp.FullName,
                    Role = emp.Role,
                    Email = emp.Email
                });
            }
            return employeeDtos;
        }
    }
}
