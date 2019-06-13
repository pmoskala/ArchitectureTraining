
namespace SFC.Notifications.Features.SendNotification
{
  public interface ISmtpClient
  {
    void Send(string email, string title, string body);
  }
}