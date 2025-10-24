// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using NotificationApp;

INotificationService pushNotification = new PushNotifier();
AppointmentService appointmentService1= new AppointmentService(pushNotification);
appointmentService1.BookAppointment("Shashi");
Console.WriteLine();
INotificationService smsNotification = new SMSNotifier();
AppointmentService appointmentService2= new AppointmentService(smsNotification);
appointmentService2.BookAppointment("Shashangan");
Console.WriteLine();
INotificationService emailNotification = new EmailNotifier();
AppointmentService appointmentService3= new AppointmentService(emailNotification);
appointmentService3.BookAppointment("Shibu");