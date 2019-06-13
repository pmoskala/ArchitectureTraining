using SFC.Accounts.Features.AccountQuery.Contract;
using SFC.Infrastructure;

namespace SFC.Accounts.Features.AccountQuery
{
  public class GetAccountsHandler : IQueryHandler<AccountsReadModel, Contract.AccountQuery>
  {
    private readonly IAccountsPerspective _perspective;

    public GetAccountsHandler(IAccountsPerspective perspective)
    {
      _perspective = perspective;
    }

    public AccountsReadModel Handle(Contract.AccountQuery request)
    {
      return _perspective.Search(request);
    }
  }
}