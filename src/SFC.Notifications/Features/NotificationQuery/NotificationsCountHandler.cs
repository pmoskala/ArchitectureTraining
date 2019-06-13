using System;
using System.Collections.Generic;
using System.Text;
using SFC.Infrastructure;
using SFC.Notifications.Features.NotificationQuery.Contract;
using SFC.Notifications.Features.SendNotification;
using SFC.Notifications.Infrastructure;

namespace SFC.Notifications.Features.NotificationQuery
{
  class NotificationsCountHandler : IQueryHandler<IEnumerable<NotificationsCountResult>, NotificationsCountRequest>
  {
    private readonly INotificationQueryRepository _notificationRepository;

    public NotificationsCountHandler(INotificationQueryRepository notificationRepository)
    {
      _notificationRepository = notificationRepository;
    }

    public IEnumerable<NotificationsCountResult> Handle(NotificationsCountRequest request)
    {
      return _notificationRepository.GetSendNotificationsCount(request.LoginNames);
    }
  }
}
