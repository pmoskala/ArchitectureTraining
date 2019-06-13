using SFC.Alerts.Features.GetAlert;
using System.Collections.Generic;

namespace SFC.UserApi.Alerts
{
    public interface IAlertRepository
    {
        void Add(Alert alert);
        IEnumerable<Alert> GetAll(string loginName);
        Alert Get(string id, string loginName);
    }
}