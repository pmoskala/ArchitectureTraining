using Automatonymous;
using SFC.Accounts.Features.CreateAccount.Contract;
using SFC.Alerts.Features.CreateAlert;
using SFC.Infrastructure;
using SFC.Notifications.Features.SendNotification.Contract;
using SFC.Notifications.Features.SetNotificationEmail.Contract;
using SFC.Processes.UserRegistration.Contract;
using System;
using System.Linq;

namespace SFC.Processes.UserRegistration
{
    public class UserRegistrationSaga : AutomatonymousStateMachine<UserRegistrationSagaData>
    {
        private readonly ICommandBus _commandBus;
        private readonly IPasswordHasher _passwordHasher;
        public Event<ConfirmUserCommand> ConfirmUserCommand { get; set; }
        public Event<RegisterUserCommand> RegisterUserCommand { get; set; }
        public State WaitingForConfirmation { get; set; }

        public UserRegistrationSaga(ICommandBus commandBus, IPasswordHasher passwordHasher)
        {
            _commandBus = commandBus;
            _passwordHasher = passwordHasher;
            UserRegistrationSagaData.States = States.ToDictionary(f => f.Name, f => f);

            Initially(
                When(RegisterUserCommand)
                    .Then(StoreDataInSaga())
                    .Then(SetNotificationEmail())
                    .Then(SendNotification())
                    .TransitionTo(WaitingForConfirmation));

            During(WaitingForConfirmation,
                When(ConfirmUserCommand)
                    .Then(CreateAccount())
                    .Then(CreateAlert())
                    .TransitionTo(Final));
        }

        private Action<BehaviorContext<UserRegistrationSagaData, ConfirmUserCommand>> CreateAlert()
        {
            return ctx => _commandBus.Send(new CreateAlertCommand(ctx.Instance.Id, ctx.Instance.AddressLine1, ctx.Instance.AddressLine2, ctx.Instance.ZipCode, ctx.Instance.LoginName));
        }

        private Action<BehaviorContext<UserRegistrationSagaData, ConfirmUserCommand>> CreateAccount()
        {
            return ctx => _commandBus.Send(new CreateAccountCommand { LoginName = ctx.Instance.LoginName });
        }

        private Action<BehaviorContext<UserRegistrationSagaData, RegisterUserCommand>> SendNotification()
        {
            return ctx => _commandBus.Send(new SendNotificationCommand
            {
                LoginName = ctx.Instance.LoginName,
                NotificationType = "Email",
                Body = "Registered",
                Title = "Title"
            });
        }

        private Action<BehaviorContext<UserRegistrationSagaData, RegisterUserCommand>> SetNotificationEmail()
        {
            return ctx => _commandBus.Send(new SetNotificationEmailCommand
            {
                Email = ctx.Instance.Email,
                LoginName = ctx.Instance.LoginName
            });
        }

        private Action<BehaviorContext<UserRegistrationSagaData, RegisterUserCommand>> StoreDataInSaga()
        {
            return ctx =>
            {
                ctx.Instance.Id = ctx.Data.Id;
                ctx.Instance.ZipCode = ctx.Data.ZipCode;
                ctx.Instance.AddressLine1 = ctx.Data.AddressLine1;
                ctx.Instance.AddressLine2 = ctx.Data.AddressLine2;
                ctx.Instance.Email = ctx.Data.Email;
                ctx.Instance.LoginName = ctx.Data.LoginName;
                ctx.Instance.BaseUrl = ctx.Data.BaseUrl;
                ctx.Instance.PasswordHash = _passwordHasher.Hash(ctx.Data.Password);

            };
        }
    }
}
