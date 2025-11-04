// See https://aka.ms/new-console-template for more information

//● Banking App 
//○ Create an interface IAccount with methods: 
//■ void Deposit(double amount); 
//■ void Withdraw(double amount); 
//■ double GetBalance(); 
//○ Then implement it in two classes: 
//■ SavingsAccount
//■ CurrentAccount 
//○ Create an interface IPaymentService with method: 
//■ void MakePayment(double amount); 
//○ Then create implementations: 
//■ CreditCardPayment
//■ UPIPayment 
//■ NetBankingPayment 
//○ Create a class PaymentProcessor that depends only on the interface, not on 
//the concrete class. Use Constructor for injecting the dependency. 
//● Notification App 
//○ Create interface INotificationService with:
//■ void Notify(string message); 
//○ Implement SMSNotifier, EmailNotifier, and PushNotifier. 
//○ Create a class AppointmentService that depends on the interface to notify
//patients after booking.


using BankingApp;

SavingsAccount savingsAccount=new SavingsAccount();
savingsAccount.Deposit(1000);
savingsAccount.Withdraw(500);
savingsAccount.Withdraw(700);
Console.WriteLine($"Balance  {savingsAccount.GetBalance()}");

Console.WriteLine();

CurrentAccount currentAccount=new CurrentAccount();
currentAccount.Deposit(2000);
currentAccount.Withdraw(500);
currentAccount.Withdraw(300);
Console.WriteLine($"Balance {currentAccount.GetBalance()}");

Console.WriteLine();

IPaymentService creditCardPayment = new CreditCardPayment();
PaymentProcessor paymentProcessor = new PaymentProcessor(creditCardPayment);
paymentProcessor.ProcessPayment(1000);

IPaymentService upiPayment = new UPIPayment();
PaymentProcessor paymentProcessor1=new PaymentProcessor(upiPayment);
paymentProcessor1.ProcessPayment(2000);

IPaymentService netBankingPayment = new NetBankingPayment();
PaymentProcessor paymentProcessor2 = new PaymentProcessor(netBankingPayment);
paymentProcessor2.ProcessPayment(400);
