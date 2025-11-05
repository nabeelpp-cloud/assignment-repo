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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IApplicationDbContext context;

        public CustomerRepository(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            return await context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int id)
        {
            var customer = await context.Customers.FindAsync(id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                return await context.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<List<Customer>> GetAllAsync()
        {
            var customers = await context.Customers.ToListAsync();
            return customers;
        }
        public async Task<Customer?> GetByIdAsync(int id)
        {
            var customer = await context.Customers.FindAsync(id);
            return customer;
        }
        public async Task<int> UpdateAsync(int id, Customer customer)
        {
            var existingCustomer = await context.Customers.FindAsync(id);
            if (existingCustomer != null)
            {
                existingCustomer.FullName = customer.FullName;
                existingCustomer.Email = customer.Email;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.IdProofNumber = customer.IdProofNumber;
                return await context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
