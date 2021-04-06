using RDI.Test.Application.Notifications;
using System.Collections.Generic;

namespace RDI.Test.Application.Interfaces
{
    public interface INotificator
    {
        bool AnyNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notificacao);
    }
}
