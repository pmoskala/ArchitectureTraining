namespace SFC.Processes.UserRegistration.Contract
{
  public class ConfirmUserCommand
  {
    public string ConfirmationId { get; set; }
    public bool Confirmed { get; set; }
  }
}