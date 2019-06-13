
namespace SFC.Tests.IntegrationTest.Mocks
{
  public class SmtpClientEmail
  {
    public string Email { get; }
    public string Title { get; }
    public string Body { get; }

    public SmtpClientEmail(string email, string title, string body)
    {
      Email = email;
      Title = title;
      Body = body;
    }
  }
}