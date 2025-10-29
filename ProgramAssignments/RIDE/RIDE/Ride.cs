using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIDE
{
    public class Ride
    {
        public static int totalRides;
        public static decimal totalEarnings;
        public static double baseFare;
        public static double surgeMultiplier;
        public string RideId;
        public string DriverName;
        public string PassengerName;
        public double DistanceKm;
        public decimal Fare;
        static Ride()
        {
            Console.WriteLine("Uber System Initialized. Ready to book rides...");
            totalRides = 1;
            baseFare = 50.0;
            totalEarnings=0;
            surgeMultiplier = 1.0;
        }
        public Ride(string driverName,string passengerName,double distance)
        {
            RideId = "Ride_" + totalRides;
            totalRides++;
            DriverName=driverName;
            PassengerName = passengerName;
            DistanceKm = distance;
            //Console.WriteLine($"{(decimal)baseFare} + (decimal)({DistanceKm} * 15 * {surgeMultiplier})");
            Fare = (decimal)baseFare + (decimal)(DistanceKm * 15 * surgeMultiplier);
            totalEarnings += Fare;

        }
        public static void SetSurgeMultiplier(double multiplier)
        {
            surgeMultiplier = multiplier > 1 ? multiplier : 1;
            //Console.WriteLine($"Surge Multiplier : {surgeMultiplier}");
        }
        public static void ShowRideSummary()
        {
            Console.WriteLine($"\nTotal Rides : {totalRides-1} \nTotal Earnings : {totalEarnings}");
        }
        public void ShowRideDetails()
        {
            Console.WriteLine($"{RideId}\t\t{DriverName}\t\t{PassengerName}\t{DistanceKm}\t{Fare}");
        }

    }
}
