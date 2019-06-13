namespace SFC.AdminApi.Dashboard
{
  public interface IDashboardPerspective
  {
    DashboardResult Search(DashboardQueryModel query);
  }
}