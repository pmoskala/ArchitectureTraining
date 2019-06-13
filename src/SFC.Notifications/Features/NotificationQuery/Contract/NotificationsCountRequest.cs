
namespace SFC.Notifications.Features.NotificationQuery
{
  public class NotificationsCountRequest
  {
    public NotificationsCountRequest(string[] loginNames)
    {
      LoginNames = loginNames;
    }

    public string[] LoginNames { get; set; }
  }
}