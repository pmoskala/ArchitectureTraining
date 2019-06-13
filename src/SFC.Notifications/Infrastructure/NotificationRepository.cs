using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using SFC.Notifications.Features.NotificationQuery;
using SFC.Notifications.Features.NotificationQuery.Contract;
using SFC.Notifications.Features.SendNotification;

namespace SFC.Notifications.Infrastructure
{
  class NotificationRepository : INotificationRepository, INotificationQueryRepository
  {
    private static readonly List<Notification> _items = new List<Notification>();

    public void Add(string email, string title, string body, DateTime date, string loginName, string notificationType)
    {
     _items.Add(new Notification(email, title, body, date, loginName, notificationType));
    }

    public IEnumerable<NotificationsCountResult> GetSendNotificationsCount(params string[] loginNames)
    {
      return _items
        .Where(f => loginNames.Contains(f.LoginName))
        .GroupBy(f => f.LoginName)
        .Select(f => new NotificationsCountResult(f.Key, f.Count()));
    }
  }
}