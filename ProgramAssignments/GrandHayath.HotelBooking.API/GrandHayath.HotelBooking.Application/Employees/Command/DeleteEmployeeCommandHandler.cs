using GrandHayath.HotelBooking.Domain.Interfaces;
using MediatR;

namespace GrandHayath.HotelBooking.Application.Employees.Command
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _repository;
        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _repository = employeeRepository;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id);
            if (employee == null)
            {
                return 0;
            }

            return await _repository.DeleteAsync(employee);
        }
    }

}
