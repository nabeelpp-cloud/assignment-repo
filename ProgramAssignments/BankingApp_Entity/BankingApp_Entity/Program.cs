// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using BankingApp_Entity;

BankingAppDbContext bankingAppDbContext = new BankingAppDbContext();


//Customer customer1 = new Customer();

//customer1.FullName = "John Smith";
//customer1.Email = "john.smith@email.com";
//customer1.PhoneNumber = "-857";
//customer1.DateOfBirth = DateTime.Parse("1987-04-12");
//customer1.Address = "123 Main St, New York, USA";
//customer1.CreatedDate = DateTime.Parse("2025-01-01");
//bankingAppDbContext.Add(customer1);

//Customer customer2 = new Customer();

//customer2.FullName = "Maria Gonzalez";
//customer2.Email = "maria.gonzalez@gmail.com";
//customer2.PhoneNumber = "-1601";
//customer2.DateOfBirth = DateTime.Parse("1990-08-25");
//customer2.Address = "45 Calle Mayor, Madrid, Spain";
//customer2.CreatedDate = DateTime.Parse("2025-02-15");
//bankingAppDbContext.Add(customer2);

//Customer customer3 = new Customer();

//customer3.FullName = "Liam O’Connor";
//customer3.Email = "liam.oconnor@outlook.com";
//customer3.PhoneNumber = "-907779";
//customer3.DateOfBirth = DateTime.Parse("1985-11-03");
//customer3.Address = "89 Abbey Rd, London, UK";
//customer3.CreatedDate = DateTime.Parse("2025-03-10");
//bankingAppDbContext.Add(customer3);

//Customer customer4 = new Customer();

//customer4.FullName = "Sophia Müller";
//customer4.Email = "sophia.mueller@gmail.com";
//customer4.PhoneNumber = "-2345780";
//customer4.DateOfBirth = DateTime.Parse("1992-07-18");
//customer4.Address = "22 Berliner Str, Berlin, Germany";
//customer4.CreatedDate = DateTime.Parse("2025-04-05");
//bankingAppDbContext.Add(customer4);

//Customer customer5 = new Customer();

//customer5.FullName = "Ethan Brown";
//customer5.Email = "ethan.brown@yahoo.com";
//customer5.PhoneNumber = "-1374";
//customer5.DateOfBirth = DateTime.Parse("1989-02-14");
//customer5.Address = "17 King St, Sydney, Australia";
//customer5.CreatedDate = DateTime.Parse("2025-05-01");
//bankingAppDbContext.Add(customer5);

//bankingAppDbContext.SaveChanges();


AccountOperations accountOperations = new AccountOperations();
//accountOperations.AddCustomer();

//accountOperations.UpdateCustomerUsingId();

//accountOperations.DeleteCustomerUsingId();

accountOperations.DisplayAllCustomer();