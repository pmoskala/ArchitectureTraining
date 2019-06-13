using System.Collections.Generic;
using SFC.Alerts.Features.GetAlert;

namespace SFC.UserApi.Alerts
{
  interface IAlertRepository
  {
    void Add(Alert alert);
    IEnumerable<Alert> GetAll(string loginName);
    Alert Get(string id, string loginName);
  }
}