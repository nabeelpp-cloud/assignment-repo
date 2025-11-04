using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationApp
{
    internal class AppointmentService
    {
        private readonly INotificationService _notificationService;
        public AppointmentService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public void BookAppointment(string name)
        {
            _notificationService.Notify(name);
        }
    }
}
