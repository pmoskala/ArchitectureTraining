using System.Threading.Tasks;
using RestEase;

namespace SFC.Tests.IntegrationTest.UserApi
{
  public interface IAccountsApi
  {
    [Post("api/v1.0/accounts")]
    Task<string> PostAccount([Body]PostAccountModel account);

    [Put("api/v1.0/confirmations/{id}")]
    Task PutAccountConfirmation([Path]string id, [Body] PutConfirmationModel confirmation);

    [Get("api/v1.0/accounts/{loginName}")]
    Task <GetAccountModel> Get([Path]string loginName);
  }
}