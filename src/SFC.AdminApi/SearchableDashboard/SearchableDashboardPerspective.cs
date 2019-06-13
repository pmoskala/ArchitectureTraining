using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace SFC.AdminApi.SearchableDashboard
{
  class SearchableDashboardPerspective : ISearchabelDashboardPerspective
  {
    private static readonly List<SearchableDashboardEntry> _items = new List<SearchableDashboardEntry>();

    public void Add(SearchableDashboardEntry searchableDashboardEntry)
    {
      _items.Add(new SearchableDashboardEntry()
        {
          LoginName = searchableDashboardEntry.LoginName,
          AlertsCount = searchableDashboardEntry.AlertsCount
      });
    }

    public SearchableDashboardEntry Get(string loginName)
    {
      return _items.FirstOrDefault(f => f.LoginName == loginName);
    }

    public void Update(SearchableDashboardEntry searchableDashboardEntry)
    {
      _items.First(f => f.LoginName == searchableDashboardEntry.LoginName).AlertsCount = searchableDashboardEntry.AlertsCount;
    }

    public SearchableDashboardResult Search(SearchableDashboardQueryModel query)
    {
      return new SearchableDashboardResult(_items.Skip(query.Skip).Take(query.Take).Where(f=>f.AlertsCount > query.AlertsCountGreaterThan));
    }
  }
}