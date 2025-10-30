// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using RIDE;


Ride.SetSurgeMultiplier(2.5);
Ride ride1 = new Ride("Nabeel","Abhinav",1.02);
Ride.SetSurgeMultiplier(0.5);
Ride ride2 = new Ride("Mafas","Ihzan",2);
Ride.SetSurgeMultiplier(2);
Ride ride3 = new Ride("Karthik","Shahin",3.5);

Ride.ShowRideSummary();
Console.WriteLine();

Console.WriteLine("Driver Name\tPassenger Name\tDistance(in km)\tFare");
ride1.ShowRideDetails();
ride2.ShowRideDetails();
ride3.ShowRideDetails();