using System.Threading.Tasks;
using RestEase;
using SFC.Tests.IntegrationTest.UserApi;

namespace SFC.Tests.IntegrationTest
{
  public interface IAdminApi
  {
    [Get("api/v1.0/dashboard")]
    Task<GetDashboardResult> GetDashboard([Query] int top, [Query] int take);

    [Get("api/v1.0/searchableDashboard")]
    Task<GetSearchableDashboardResult> GetSearchableDashboard([Query] int top, [Query] int take, [Query] int alertsCountGreaterThan);
  }
}