
namespace SFC.Alerts.Features.GetAlert
{
  public class GetAlertRequest
  {
    public string Id { get; }
    public string LoginName { get; }

    public GetAlertRequest(string id, string loginName)
    {
      Id = id;
      LoginName = loginName;
    }
  }
}