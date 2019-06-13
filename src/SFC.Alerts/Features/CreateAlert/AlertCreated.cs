
namespace SFC.Alerts.Features.CreateAlert
{
  public class AlertCreatedEvent
  {
    public string AlertId { get; }
    public string AdresLine1 { get; }
    public string AdresLine2 { get; }
    public string LoginName { get; set; }
    public string ZipCode { get; set; }


    public AlertCreatedEvent(string alertId, string adresLine1, string adresLine2, string zipCode, string loginName)
    {
       AlertId = alertId;
      AdresLine1 = adresLine1;
      AdresLine2 = adresLine2;
      LoginName = loginName;
      ZipCode = zipCode;
    }
  }
}