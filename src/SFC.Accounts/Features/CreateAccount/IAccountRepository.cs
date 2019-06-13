namespace SFC.Accounts.Features.CreateAccount
{
  internal interface IAccountRepository
  {
    void Add(string commandLoginName);
  }
}