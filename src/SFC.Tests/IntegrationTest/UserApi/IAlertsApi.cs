using RestEase;
using System.Threading.Tasks;

namespace SFC.Tests.IntegrationTest.UserApi
{
    public interface IAlertsApi
    {
        [Post("api/v1.0/alerts")]
        Task<Response<string>> PostAlert([Body]PostAlertModel account);

        [Get("api/v1.0/alerts/{alertId}")]
        Task<GetAlertModel> GetAlert([Path] string alertId, [Query]string loginName);
    }
}