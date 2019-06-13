namespace SFC.Notifications.Features.SendNotification.Contract
{
  public class NotificationSentEvent
  {
    public string LoginName { get; set; }
    public string Email { get; set; }
    public string NotificationType { get; set; }
  }
}