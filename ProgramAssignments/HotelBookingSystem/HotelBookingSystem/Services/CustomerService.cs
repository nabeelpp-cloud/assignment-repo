using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public interface ICustomerService
    {
        public string AddCustomer(Customer customer);
        public string UpdateCustomer(int id, string? fullName, string? email, string? phoneNumber, string? idProofNumber);
        public string DeleteCustomer(int id);
        public List<Customer> GetCustomers();
        public Customer GetCustomerByCustomerId(int customerId);
    }
    public class CustomerService : ICustomerService
    {
        private readonly HotelManagementDbContext _context;
        public CustomerService(HotelManagementDbContext context)
        {
            _context = context;
        }
        public string AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            var resp= _context.SaveChanges();
            if (resp > 0)
                return "Customer added Succesfully";
            return "Error adding customer";
        }

        public string DeleteCustomer(int id)
        {
            var cust=_context.Customers.FirstOrDefault(x => x.Id == id);
            if (cust == null)
                return "Customer NotFound";
            _context.Customers.Remove(cust);
            var resp=_context.SaveChanges();
            if (resp > 0)
                return "Customer removed Succesfully";
            return "Error removing customer";
        }

        public Customer GetCustomerByCustomerId(int id)
        {
            var cust = _context.Customers.FirstOrDefault(x => x.Id == id);
            return cust;
        }

        public List<Customer> GetCustomers()
        {
            var cust = _context.Customers.ToList();
            return cust;
        }

        public string UpdateCustomer(int id,string? fullName, string? email, string? phoneNumber, string? idProofNumber)
        {
            var cust = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (cust == null)
                return "Customer NotFound";
            if (fullName != null)
                cust.FullName = fullName;
            if(email != null) 
                cust.Email = email;
            if(phoneNumber!=null) 
                cust.PhoneNumber = phoneNumber;
            if(idProofNumber != null)
                cust.IdProofNumber = idProofNumber;
            var resp = _context.SaveChanges();
            if (resp > 0)
                return "Customer updated Succesfully";
            return "Error updating customer";
        }
    }
}
