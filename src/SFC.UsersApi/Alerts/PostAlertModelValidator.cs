using FluentValidation;

namespace SFC.UserApi.Alerts
{
  public class PostAlertModelValidator : AbstractValidator<PostAlertModel>
  {
    public PostAlertModelValidator()
    {
      // validation rules goes here
    }
  }
}