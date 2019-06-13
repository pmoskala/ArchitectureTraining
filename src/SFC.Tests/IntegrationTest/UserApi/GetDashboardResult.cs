using System.Collections.Generic;
using SFC.Tests.IntegrationTest.UserApi;

namespace SFC.Tests.IntegrationTest
{
  public class GetDashboardResult
  {
    public IEnumerable<DashboardEntry> Results { get; }

    public GetDashboardResult(IEnumerable<DashboardEntry> results)
    {
      Results = results;
    }
  }
}