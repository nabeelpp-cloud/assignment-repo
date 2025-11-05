using GrandHayath.HotelBooking.Application.Dtos;
using GrandHayath.HotelBooking.Infrastructure.Data;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Employees.Query
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IApplicationDbContext dbContext;
        public GetEmployeeByIdQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await dbContext.Employees.FindAsync(request.Id , cancellationToken);
            if (employee == null)
            {
                return null;
            }
            return new EmployeeDto
            {
                HotelId = employee.HotelId,
                FullName = employee.FullName,
                Role = employee.Role,
                Email = employee.Email
            };
        }
    }
}
