namespace SFC.Alerts.Features.CreateAlert
{
  public class CreateAlertCommand
  {
    public string AdresLine2 { get; set; }
    public string AdresLine1 { get; set; }
    public string Id { get; set; }
    public string ZipCode { get; set; }
    public string LoginName { get; set; }

    public CreateAlertCommand(string id, string adresLine1, string adresLine2, string zipCode, string loginName)
    {
      Id = id;
      AdresLine1 = adresLine1;
      AdresLine2 = adresLine2;
      ZipCode = zipCode;
      LoginName = loginName;
    }

    
  }
}