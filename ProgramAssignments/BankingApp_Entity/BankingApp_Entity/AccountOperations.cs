using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp_Entity;

namespace BankingApp_Entity
{
    public class AccountOperations
    {
        BankingAppDbContext bankingAppDbContext=new BankingAppDbContext();
        public void AddCustomer()
        {
            Customer customer = new Customer();
            Console.Write("Enter Full Name : ");
            customer.FullName =Console.ReadLine();
            Console.Write("Enter Email : ");
            customer.Email = Console.ReadLine();
            Console.Write("Enter PhoneNumber : ");
            customer.PhoneNumber = Console.ReadLine();
            Console.Write("Enter DateOfBirth : ");
            customer.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Address : ");
            customer.Address = Console.ReadLine();
           
            customer.CreatedDate = DateTime.Now;
            bankingAppDbContext.Add(customer);
            bankingAppDbContext.SaveChanges();
        }
        public void UpdateCustomerUsingId()
        {
            Console.Write("Enter Customer Id to change : ");
            int id=int.Parse(Console.ReadLine());
            var cust = bankingAppDbContext.Find<Customer>(id);
            if (cust == null) 
            {
                Console.WriteLine("There is no customer in that Id\n");
                return;
            }
            Console.Write("Enter New Adress : ");
            var address= Console.ReadLine();
            cust.Address = address;
            bankingAppDbContext.SaveChanges();

        }
        public void DeleteCustomerUsingId()
        {
            Console.Write("Enter Customer Id to change : ");
            int id = int.Parse(Console.ReadLine());
            var cust = bankingAppDbContext.Find<Customer>(id);
            if (cust == null)
            {
                Console.WriteLine("There is no customer in that Id\n");
                return;
            }
            bankingAppDbContext.Remove(cust);
            int res=bankingAppDbContext.SaveChanges();
            if(res > 0)
            {
                Console.WriteLine("Deleted Succesfully");
            }
            else
            {
                Console.WriteLine("Dleteing cusomer Failed");
            }
        }
        public void DisplayAllCustomer()
        {
            List<Customer> cust = bankingAppDbContext.Customers.ToList();
            foreach (var row in cust) 
            {
                Console.WriteLine($"Name : {row.FullName} \nEmail : {row.Email} \nPhoneNumber{row.PhoneNumber} \n" +
                    $"DateOfBirth : {row.DateOfBirth} \nAddress : {row.Address} CreatedDate : {row.CreatedDate}\n");
            }
        }
    }
}
