
namespace SFC.Alerts.Features.GetAlert
{
  public class Alert
  {
    public string Id { get; }
    public string AdresLine1 { get; }
    public string AdresLine2 { get; }
    public string ZipCode { get; }
    public string LoginName { get; set; }
    public bool Active { get; set; }

    public Alert(string id, string adresLine1, string adresLine2, string zipCode, string loginName)
    {
      Id = id;
      AdresLine1 = adresLine1;
      AdresLine2 = adresLine2;
      ZipCode = zipCode;
      LoginName = loginName;
      Active = true;
    }
  }
}