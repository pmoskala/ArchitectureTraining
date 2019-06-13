using System.Collections.Generic;
using System.Linq;
using SFC.Alerts;
using SFC.Alerts.Features.GetAlert;

namespace SFC.UserApi.Alerts
{
  class AlertRepository : IAlertRepository
  {
    private static readonly List<Alert> _items = new List<Alert>();

    public void Add(Alert alert)
    {
      _items.Add(alert);
    }

    public IEnumerable<Alert> GetAll(string loginName)
    {
      return _items.Where(f=>f.LoginName == loginName);
    }

    public Alert Get(string id, string loginName)
    {
      return _items.First(f => f.Id == id && f.LoginName == loginName);
    }
  }
}