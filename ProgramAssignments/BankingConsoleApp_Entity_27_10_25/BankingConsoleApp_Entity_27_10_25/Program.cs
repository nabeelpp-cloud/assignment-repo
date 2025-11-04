// See https://aka.ms/new-console-template for more information



using BankingConsoleApp_Entity_27_10_25;
using BankingConsoleApp_Entity_27_10_25.Models;

BankingAppDbContext bankingAppDbContext = new BankingAppDbContext();
AccountOperations operations = new AccountOperations(bankingAppDbContext);

//Customer customer = new Customer();
//customer.FullName = "Nabeel P P";
//customer.Email = "nabeelpp2002@gmail.com";
//customer.PhoneNumber = "7736674340";
//customer.DateOfBirth = DateTime.Parse("2002-09-10");

//Address address = new Address();
//address.Street = "KelappanMukku";
//address.City = "Koyyode";
//address.State = "Kerala";
//address.PostalCode = "670621";
//address.Country = "India";

//customer.Address = address;

//Account account = new Account();
//account.AccountNumber = "SBI007811909";
//account.Balance = 5634.2;
//customer.Accounts.Add(account);
//operations.AddCustomer(customer);


//operations.DisplayCustomers();

//Address address2 = new Address();
//address2.Street = "Uruvachal";
//address2.City = "ThazheChovva";
//address2.State = "Kerala";
//address2.PostalCode = "670006";
//address2.Country = "India";


//operations.AddAddress(1,address2);

//Account account2 = new Account();
//account2.AccountNumber = "FED0089654";
//account2.Balance = 34.2;

//operations.AddAccount(1, account2);


operations.DeleteAccount(1,1);