using SFC.Alerts.Features.CreateAlert;
using SFC.Infrastructure;
using SFC.Notifications.Features.SendNotification.Contract;

namespace SFC.Processes.AlertNotification
{
    class AlertCreatedEventHandler : IEventHandler<AlertCreatedEvent>
    {
        private readonly ICommandBus _commandBus;

        public AlertCreatedEventHandler(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }
        public void Handle(AlertCreatedEvent @event)
        {
            _commandBus.Send(new SendNotificationCommand
            {
                LoginName = @event.LoginName,
                NotificationType = "email",
                Body = $"This is body: {@event.AlertId}",
                Title = "Title"
            });
        }
    }
}
