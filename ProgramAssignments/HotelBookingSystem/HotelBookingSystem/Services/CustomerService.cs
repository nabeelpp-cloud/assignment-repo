using HotelBookingSystem.DTOs;
using HotelBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Services
{
    public interface ICustomerService
    {
        public Task<string> AddCustomer(Customer customer);
        public Task<string> UpdateCustomer(int id, CustomerDto customerDto);
        public Task<string> DeleteCustomer(int id);
        public Task<List<Customer>> GetCustomers();
        public Task<Customer> GetCustomerById(int Id);
    }
    public class CustomerService : ICustomerService
    {
        private readonly HotelManagementDbContext _context;
        public CustomerService(HotelManagementDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            var resp=await  _context.SaveChangesAsync();
            if (resp > 0)
                return "Customer added Succesfully";
            return "Error adding customer";
        }

        public async Task<string> DeleteCustomer(int id)
        {
            var cust=await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (cust == null)
                return "Customer NotFound";
            _context.Customers.Remove(cust);
            var resp=await _context.SaveChangesAsync();
            if (resp > 0)
                return "Customer removed Succesfully";
            return "Error removing customer";
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var cust =await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return cust;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var cust =await _context.Customers.ToListAsync();
            return cust;
        }

        public async Task<string> UpdateCustomer(int id, CustomerDto customerDto)
        {
            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCustomer == null)
                return "Customer Not Found";

            if (!string.IsNullOrWhiteSpace(customerDto.FullName))
                existingCustomer.FullName = customerDto.FullName;

            if (!string.IsNullOrWhiteSpace(customerDto.Email))
                existingCustomer.Email = customerDto.Email;

            if (!string.IsNullOrWhiteSpace(customerDto.PhoneNumber))
                existingCustomer.PhoneNumber = customerDto.PhoneNumber;

            if (!string.IsNullOrWhiteSpace(customerDto.IdProofNumber))
                existingCustomer.IdProofNumber = customerDto.IdProofNumber;

            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0 ? "Customer updated successfully" : "Error updating customer";
        }

    }
}
