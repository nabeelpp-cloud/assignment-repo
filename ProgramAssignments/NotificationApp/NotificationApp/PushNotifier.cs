using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationApp
{
    internal class PushNotifier : INotificationService
    {
        public void Notify(string name)
        {
            Console.WriteLine($"Push Notification sent: Dear {name} your booking Confirmed");
        }
    }
}
