using GrandHayath.HotelBooking.Domain.Entity;
using GrandHayath.HotelBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHayath.HotelBooking.Infrastructure.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IApplicationDbContext dbContext;

        public EmployeeRepository(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> AddAsync(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            if(employee != null)
            {
                dbContext.Employees.Remove(employee);
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var employees = await dbContext.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            var employee =await dbContext.Employees.FindAsync(id);
            return employee;
        }

        public async Task<int> UpdateAsync(int id, Employee employee)
        {
            var existingEmployee =await dbContext.Employees.FindAsync(id);
            if (existingEmployee != null) 
            {
                existingEmployee.FullName = employee.FullName;
                existingEmployee.HotelId = employee.HotelId;
                existingEmployee.Email = employee.Email;
                existingEmployee.Role = employee.Role;
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
