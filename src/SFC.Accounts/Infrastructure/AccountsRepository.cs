using System.Collections.Generic;
using System.Linq;
using SFC.Accounts.Features.AccountQuery;
using SFC.Accounts.Features.AccountQuery.Contract;
using SFC.Accounts.Features.CreateAccount;

namespace SFC.Accounts.Infrastructure
{
  class AccountsRepository : IAccountsPerspective, IAccountRepository
  {
    private static readonly List<string> _items = new List<string>();

    public AccountReadModel Get(string loginName)
    {
      return _items.Where(f => f == loginName).Select(f => new AccountReadModel(f)).FirstOrDefault();
    }

    public AccountsReadModel Search(AccountQuery accountQuery)
    {
      return new AccountsReadModel(
        _items
          .Skip(accountQuery.Skip)
          .Take(accountQuery.Take)
          .Select(f => new AccountReadModel(f)));
    }

    public void Add(string loginName)
    {
      _items.Add(loginName);
    }
  }
}