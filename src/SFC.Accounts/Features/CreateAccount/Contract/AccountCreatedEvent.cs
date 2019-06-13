namespace SFC.Accounts.Features.CreateAccount.Contract
{
  public class AccountCreatedEvent
  {
    public AccountCreatedEvent(string loginName)
    {
      LoginName = loginName;
    }

    public string LoginName { get; set; }
  }
}
