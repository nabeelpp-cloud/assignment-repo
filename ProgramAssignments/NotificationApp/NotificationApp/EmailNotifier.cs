using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NotificationApp
{
    internal class EmailNotifier : INotificationService
    {
        public void Notify(string name)
        {
            Console.WriteLine($"Email sent: Dear {name} your booking Confirmed");
        }
    }
}
