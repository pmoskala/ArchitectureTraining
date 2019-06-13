namespace SFC.Tests.IntegrationTest.UserApi
{
  public class PutConfirmationModel
  {
    public PutConfirmationModel(bool confirm)
    {
      Confirm = confirm;
    }

    public bool Confirm { get; set; }
  }
}