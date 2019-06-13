
namespace SFC.Notifications.Features.SetNotificationEmail.Contract
{
  public class SetNotificationEmailCommand
  {
    public string Email { get; set; }
    public string LoginName { get; set; }
  }
}