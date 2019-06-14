using SFC.Accounts.Features.AccountQuery.Contract;
using SFC.Infrastructure;
using SFC.Notifications.Features.NotificationQuery;
using SFC.Notifications.Features.NotificationQuery.Contract;
using System.Collections.Generic;
using System.Linq;

namespace SFC.AdminApi.Dashboard
{
    class DashboardPerspective : IDashboardPerspective
    {
        private readonly IQuery _query;

        public DashboardPerspective(IQuery query)
        {
            _query = query;
        }
        public DashboardResult Search(DashboardQueryModel query)
        {
            AccountsReadModel result = _query.Query<AccountsReadModel, AccountQuery>(new AccountQuery
            {
                Skip = query.Top,
                Take = query.Take
            });

            IEnumerable<NotificationsCountResult> counts = _query.Query<IEnumerable<NotificationsCountResult>, NotificationsCountRequest>(
                new NotificationsCountRequest(result.Accounts.Select(x => x.LoginName).ToArray()));

            IEnumerable<DashboardEntry> dashboardEntries = counts.Select(x => new DashboardEntry
            {
                LoginName = x.LoginName,
                EmailsSentCount = x.Count
            });

            return new DashboardResult(dashboardEntries);
        }
    }
}