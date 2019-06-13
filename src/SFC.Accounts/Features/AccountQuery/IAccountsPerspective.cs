using SFC.Accounts.Features.AccountQuery.Contract;

namespace SFC.Accounts.Features.AccountQuery
{
  public interface IAccountsPerspective
  {
    AccountReadModel Get(string loginName);
    AccountsReadModel Search(Contract.AccountQuery accountQuery);
  }
}
