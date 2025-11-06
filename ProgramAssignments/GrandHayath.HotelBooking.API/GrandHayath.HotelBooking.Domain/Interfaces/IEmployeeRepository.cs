using GrandHayath.HotelBooking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<int> AddAsync(Employee employee);
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);

        Task<int> DeleteAsync(Employee employee);
        Task<int> UpdateAsync(Employee employee);
    }
}
