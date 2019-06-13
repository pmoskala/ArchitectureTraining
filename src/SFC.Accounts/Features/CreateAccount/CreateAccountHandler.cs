using SFC.Accounts.Features.CreateAccount.Contract;
using SFC.Infrastructure;

namespace SFC.Accounts.Features.CreateAccount
{
  class CreateAccountHandler : ICommandHandler<CreateAccountCommand>
  {
    private readonly IAccountRepository _accountRepository;
    private readonly IEventBus _eventBus;

    public CreateAccountHandler(IAccountRepository accountRepository, IEventBus eventBus)
    {
      _accountRepository = accountRepository;
      _eventBus = eventBus;
    }

    public void Handle(CreateAccountCommand command)
    {
      _accountRepository.Add(command.LoginName);
      _eventBus.Publish(new AccountCreatedEvent(command.LoginName));
    }
  }
}
