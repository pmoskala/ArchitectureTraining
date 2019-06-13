using System;
using System.Collections.Generic;
using SFC.Notifications.Features.NotificationQuery.Contract;
using SFC.Notifications.Infrastructure;

namespace SFC.Notifications.Features.SendNotification
{
  internal interface INotificationRepository 
  {
    void Add(string email, string title, string body, DateTime date, string loginName, string notificationType);
  }
}