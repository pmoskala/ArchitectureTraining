namespace SFC.Notifications.Features.GetNotificationEmail
{
  internal interface IEmailPerspective
  {
    string GetEmail(string loginName);
  }
}