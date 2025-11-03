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
        private static string _idPrefix= "Ride_";
        public static decimal totalEarnings;
        public static double baseFare;
        public static double surgeMultiplier;
        public string RideId { get; set; }
        public string DriverName {  get; set; }
        public string PassengerName {  get; set; }
        public double DistanceKm {  get; set; }
        public decimal Fare {  get; set; }
        static Ride()
        {
            Console.WriteLine("Uber System Initialized. Ready to book rides...");
            totalRides = 0;
            baseFare = 50.0;
            totalEarnings=0;
            surgeMultiplier = 1.0;
        }
        public Ride(string driverName,string passengerName,double distance)
        {
            RideId = _idPrefix+(1000 + totalRides);
            totalRides++;
            DriverName=driverName;
            PassengerName = passengerName;
            DistanceKm = distance;
            //Console.WriteLine($"{(decimal)baseFare} + (decimal)({DistanceKm} * 15 * {surgeMultiplier})");
            Fare = CalculateFare(DistanceKm);
            totalEarnings += Fare;

        }
        public static void SetSurgeMultiplier(double multiplier)
        {
            surgeMultiplier = multiplier > 1 ? multiplier : 1;
            //Console.WriteLine($"Surge Multiplier : {surgeMultiplier}");
        }
        public static void ShowRideSummary()
        {
            Console.WriteLine($"\nTotal Rides : {totalRides} \nTotal Earnings : {totalEarnings}");
        }
        public void ShowRideDetails()
        {
            Console.WriteLine($"{RideId}\t{DriverName}\t\t{PassengerName}\t\t{DistanceKm}\t\t{Fare}");
        }
        private static decimal CalculateFare(double distanceKm)
        {
            return Math.Round((decimal)(baseFare + (distanceKm * 15 * surgeMultiplier)), 2);
        }
    }
}
