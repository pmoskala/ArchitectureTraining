namespace SFC.Notifications.Features.GetNotificationEmail.Contract
{
  public class GetEmailResponse
  {
    public GetEmailResponse(string email)
    {
      Email = email;
    }

    public string Email { get; set; }
  }
}