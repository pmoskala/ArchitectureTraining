using RestEase;
using System.Threading.Tasks;

namespace SFC.Tests.IntegrationTest.UserApi
{
    public interface IAlertsApi
    {
        [Post("api/alerts")]
        Task<Response<string>> PostAlert([Body]PostAlertModel account);

        [Get("api/alerts/{alertId}")]
        Task<GetAlertModel> GetAlert([Path] string alertId, [Query]string loginName);
    }
}