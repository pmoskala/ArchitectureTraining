using System.Collections.Generic;

namespace SFC.Accounts.Features.AccountQuery.Contract
{
  public class AccountsReadModel
  {
    public AccountsReadModel(IEnumerable<AccountReadModel> accounts)
    {
      Accounts = accounts;
    }

    public IEnumerable<AccountReadModel> Accounts { get; set; }
  }
}