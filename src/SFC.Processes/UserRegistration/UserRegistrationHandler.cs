using Automatonymous;
using SFC.Accounts.Features.AccountQuery.Contract;
using SFC.Infrastructure;
using SFC.Processes.UserRegistration.Contract;

namespace SFC.Processes.UserRegistration
{
    class UserRegistrationHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly ICommandBus _commandBus;
        private readonly ISagaRepository _sagaRepository;
        private readonly IQueryBus _query;
        private readonly IPasswordHasher _passwordHasher;

        public UserRegistrationHandler(
          ICommandBus commandBus,
          ISagaRepository sagaRepository,
          IQueryBus query,
          IPasswordHasher passwordHasher)
        {
            _commandBus = commandBus;
            _sagaRepository = sagaRepository;
            _query = query;
            _passwordHasher = passwordHasher;
        }

        public void Handle(RegisterUserCommand command)
        {
            if (_query.Query<AccountReadModel, string>(command.LoginName) != null)
            {
                throw new LoginNameAlreadyUsedException(command.LoginName);
            }

            if (_sagaRepository.Get<UserRegistrationSagaData>(command.LoginName) != null)
            {
                throw new LoginNameAlreadyUsedException(command.LoginName);
            }

            UserRegistrationSaga saga = new UserRegistrationSaga(_commandBus, _passwordHasher);
            UserRegistrationSagaData data = new UserRegistrationSagaData { Id = command.Id };
            saga.RaiseEvent(data, saga.RegisterUserCommand, command);
            _sagaRepository.Save(data.Id, data);
        }
    }
}