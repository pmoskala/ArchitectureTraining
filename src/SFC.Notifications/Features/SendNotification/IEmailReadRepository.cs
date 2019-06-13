
namespace SFC.Notifications.Features.SendNotification
{
  internal interface IEmailReadRepository
  {
    string GetEmail(string loginName);
  }
}