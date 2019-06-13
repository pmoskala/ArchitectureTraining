using System.Collections.Generic;

namespace SFC.AdminApi.Dashboard
{
  class DashboardPerspective : IDashboardPerspective
  {
    public DashboardResult Search(DashboardQueryModel query)
    {
      // implement gathering data from other services

      List<DashboardEntry> entries = new List<DashboardEntry>();

      return new DashboardResult(entries);
    }
  }
}