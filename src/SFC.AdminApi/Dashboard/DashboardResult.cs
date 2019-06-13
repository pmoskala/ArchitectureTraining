using System.Collections.Generic;

namespace SFC.AdminApi.Dashboard
{
  public class DashboardResult
  {
    public IEnumerable<DashboardEntry> Results { get; }

    public DashboardResult(IEnumerable<DashboardEntry> results)
    {
      Results = results;
    }
  }
}