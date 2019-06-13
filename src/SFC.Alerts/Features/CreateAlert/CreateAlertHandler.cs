using SFC.Alerts.Features.GetAlert;
using SFC.Infrastructure;
using SFC.UserApi.Alerts;

namespace SFC.Alerts.Features.CreateAlert
{
    class CreateAlertHandler : ICommandHandler<CreateAlertCommand>
    {
        private readonly IAlertRepository _alertRepository;
        private readonly IEventBus _eventBus;

        public CreateAlertHandler(IAlertRepository alertRepository, IEventBus eventBus)
        {
            _alertRepository = alertRepository;
            _eventBus = eventBus;
        }
        public void Handle(CreateAlertCommand command)
        {
            var alert1 = new Alert(command.Id, command.AdresLine1, command.AdresLine2, command.ZipCode, command.LoginName);
            _alertRepository.Add(alert1);
            _eventBus.Publish(new AlertCreatedEvent(command.Id, command.AdresLine1, command.AdresLine2, command.ZipCode, command.LoginName));
        }
    }
}
