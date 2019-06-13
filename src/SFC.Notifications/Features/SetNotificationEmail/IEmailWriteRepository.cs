
namespace SFC.Notifications.Features.SetNotificationEmail
{
  internal interface IEmailWriteRepository
  {
    void Set(string loginName, string email);
  }
}
