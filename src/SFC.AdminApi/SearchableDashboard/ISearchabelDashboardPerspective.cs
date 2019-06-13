namespace SFC.AdminApi.SearchableDashboard
{
  public interface ISearchabelDashboardPerspective
  {
    void Add(SearchableDashboardEntry searchableDashboardEntry);
    SearchableDashboardEntry Get(string eventLoginName);
    void Update(SearchableDashboardEntry searchableDashboardEntry);
    SearchableDashboardResult Search(SearchableDashboardQueryModel query);
  }
}