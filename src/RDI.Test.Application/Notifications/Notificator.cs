using RDI.Test.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RDI.Test.Application.Notifications
{
    public class Notificator : INotificator
    {
        private List<Notification> _notifications;

        public Notificator()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool AnyNotification()
        {
            return _notifications.Any();
        }
    }
}