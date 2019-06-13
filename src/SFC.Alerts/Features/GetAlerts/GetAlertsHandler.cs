using System;
using System.Collections.Generic;
using SFC.Alerts.Features.GetAlert;
using SFC.Infrastructure;

namespace SFC.Alerts.Features.GetAlerts
{
  class GetAlertsHandler : IQueryHandler<IEnumerable<Alert>, string>
  {
    public IEnumerable<Alert> Handle(string request)
    {
      throw new NotImplementedException();
    }
  }
}