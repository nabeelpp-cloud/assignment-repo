using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationApp
{
    internal interface INotificationService
    {
        public void Notify(string message);
    }
}
