namespace SFC.Accounts.Features.AccountQuery.Contract
{
  public class AccountReadModel
  {
    public AccountReadModel(string loginName)
    {
      LoginName = loginName;
    }

    public string LoginName { get; set; }
  }
}