namespace SFC.UserApi.Accounts
{
  public class GetAccountModel
  {
    public GetAccountModel(string loginName, string email)
    {
      LoginName = loginName;
      Email = email;
    }

    public string Email { get; set; }
    public string LoginName { get; set; }
  }
}