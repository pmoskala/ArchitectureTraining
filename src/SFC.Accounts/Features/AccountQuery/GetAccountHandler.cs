using SFC.Accounts.Features.AccountQuery.Contract;
using SFC.Infrastructure;

namespace SFC.Accounts.Features.AccountQuery
{
  public class GetAccountHandler : IQueryHandler<AccountReadModel, string>
  {
    private readonly IAccountsPerspective _perspective;

    public GetAccountHandler(IAccountsPerspective perspective)
    {
      _perspective = perspective;
    }

    public AccountReadModel Handle(string loginName)
    {
      return _perspective.Get(loginName);
    }
  }
}