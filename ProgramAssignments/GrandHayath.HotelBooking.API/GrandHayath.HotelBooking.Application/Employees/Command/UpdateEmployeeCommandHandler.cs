using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Employees.Command
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _repository;
        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _repository = employeeRepository;
        }
        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var existingEmployee = await _repository.GetByIdAsync(request.Id);

            if (existingEmployee == null)
            {
                return 0;
            }

            existingEmployee.FullName = request.FullName;
            existingEmployee.Email = request.Email;
            existingEmployee.HotelId = request.HotelId;
            existingEmployee.Role = request.Role;

            return await _repository.UpdateAsync(existingEmployee);

        }
    }

}
