using System;
using System.Collections.Generic;
using System.Text;
using SFC.Infrastructure;
using SFC.Notifications.Features.GetNotificationEmail.Contract;
using SFC.Notifications.Features.SendNotification;

namespace SFC.Notifications.Features.GetNotificationEmail
{
  class GetNotificationEmailQueryHandler : IQueryHandler<GetEmailResponse, string>
  {
    private readonly IEmailReadRepository _repository;

    public GetNotificationEmailQueryHandler(IEmailReadRepository repository)
    {
      _repository = repository;
    }

    public GetEmailResponse Handle(string loginName)
    {
      return new GetEmailResponse(_repository.GetEmail(loginName));
    }
  }
}
