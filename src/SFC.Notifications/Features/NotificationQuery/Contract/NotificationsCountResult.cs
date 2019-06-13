
namespace SFC.Notifications.Features.NotificationQuery.Contract
{
  public class NotificationsCountResult
  {
    public NotificationsCountResult(string loginName, int count)
    {
      LoginName = loginName;
      Count = count;
    }

    public string LoginName { get; set; }
    public int Count { get; set; }
  }
}