
using BankingConsoleApp_Entity_27_10_25.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp_Entity_27_10_25
{
    public interface IAccountOperations
    {
        public void AddCustomer(Customer customer);
        public void DisplayCustomers();

        public void AddAddress(int customerId, Address address);
        public void AddAccount(int customerId, Account account);
        public void DeleteAccount(int customerId, int accountId);

    }
    public class AccountOperations : IAccountOperations
    {


        private readonly BankingAppDbContext _dbContext;

        public AccountOperations(BankingAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddAccount(int customerId, Account account)
        {
            var customer = _dbContext.Customers
                .Include(c => c.Accounts)
                .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                Console.WriteLine(" Customer not found.");
                return;
            }

            customer.Accounts.Add(account);
            _dbContext.SaveChanges();

            Console.WriteLine($"Account '{account.AccountNumber}' added successfully for {customer.FullName}.");
        }


        public void AddAddress(int customerId, Address address)
        {
            var customer = _dbContext.Customers
                .Include(c => c.Address)
                .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            if (customer.Address == null)
            {
                customer.Address = address;
                Console.WriteLine("Address added successfully.");
            }
            else
            {
                customer.Address.Street = address.Street;
                customer.Address.City = address.City;
                customer.Address.State = address.State;
                customer.Address.PostalCode = address.PostalCode;
                customer.Address.Country = address.Country;

                Console.WriteLine("Address updated successfully.");
            }

            _dbContext.SaveChanges();
        }


        public void AddCustomer(Customer customer)
        {
            
            _dbContext.Add(customer);
            int resp=_dbContext.SaveChanges();
            if (resp > 0)
            {
                Console.WriteLine("Customer Added Succesfully");
            }
            else
            {
                Console.WriteLine("Can't add the customer");
            }
        }

        public void DeleteAccount(int customerId, int accountId)
        {
            var customer = _dbContext.Customers
                .Include(c => c.Accounts)
                .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            var account = customer.Accounts.FirstOrDefault(a => a.Id == accountId);
            if (account == null)
            {
                Console.WriteLine("Account not found for this customer.");
                return;
            }

            customer.Accounts.Remove(account);
            _dbContext.SaveChanges();

            Console.WriteLine($"Account '{account.AccountNumber}' deleted successfully for {customer.FullName}.");
        }


        public void DisplayCustomers()
        {
            var customers=_dbContext.Customers
                .Include(c=>c.Accounts)
                .Include(c=>c.Address)
                .ToList();
            
            foreach(Customer customer in customers)
            {
                Console.WriteLine($"Customer Name : {customer.FullName}\n" +
                    $"Address : {customer.Address.Street},{customer.Address.City}, {customer.Address.PostalCode}, {customer.Address.Country} \n");
                Console.WriteLine("Accounts : ");
                int count = 1;
                foreach (Account account in customer.Accounts)
                {
                    
                    Console.WriteLine($"\t{count++} : {account.AccountNumber}");
                }
            }
        }
    }
}
