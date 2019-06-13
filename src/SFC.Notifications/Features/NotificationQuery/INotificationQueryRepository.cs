using System.Collections.Generic;
using SFC.Notifications.Features.NotificationQuery.Contract;

namespace SFC.Notifications.Features.NotificationQuery
{
  internal interface INotificationQueryRepository 
  {
    IEnumerable<NotificationsCountResult> GetSendNotificationsCount(string[] requestLoginNames);
  }
}