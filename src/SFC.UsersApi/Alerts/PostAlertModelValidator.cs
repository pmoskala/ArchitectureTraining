using FluentValidation;

namespace SFC.UserApi.Alerts
{
    public class PostAlertModelValidator : AbstractValidator<PostAlertModel>
    {
        public PostAlertModelValidator()
        {
            RuleFor(f => f.Id).NotNull().NotEmpty();
            RuleFor(f => f.LoginName).NotNull().NotEmpty();
            RuleFor(f => f.ZipCode).NotNull().NotEmpty();
        }
    }
}