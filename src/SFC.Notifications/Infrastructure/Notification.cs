using System;

namespace SFC.Notifications.Infrastructure
{
  internal class Notification
  {
    public string Email { get; }
    public string Title { get; }
    public string Body { get; }
    public DateTime Date { get; }
    public string LoginName { get; }
    public string NotificationType { get; }

    public Notification(string email, string title, string body, DateTime date, string loginName, string notificationType)
    {
      Email = email;
      Title = title;
      Body = body;
      Date = date;
      LoginName = loginName;
      NotificationType = notificationType;
    }
  }
}