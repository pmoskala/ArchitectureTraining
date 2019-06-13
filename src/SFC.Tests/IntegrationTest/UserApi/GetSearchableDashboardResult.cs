using System.Collections.Generic;
using SFC.AdminApi.SearchableDashboard;

namespace SFC.Tests.IntegrationTest.UserApi
{
  public class GetSearchableDashboardResult
  {
    public IEnumerable<SearchableDashboardEntry> Results { get; }

    public GetSearchableDashboardResult(IEnumerable<SearchableDashboardEntry> results)
    {
      Results = results;
    }
  }
}