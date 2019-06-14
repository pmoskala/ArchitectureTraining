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
        private readonly IQueryBus _queryBus;

        public DashboardPerspective(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }
        public DashboardResult Search(DashboardQueryModel query)
        {
            AccountsReadModel result = _queryBus.Query<AccountsReadModel, AccountQuery>(new AccountQuery
            {
                Skip = query.Top,
                Take = query.Take
            });

            IEnumerable<NotificationsCountResult> counts = _queryBus.Query<IEnumerable<NotificationsCountResult>, NotificationsCountRequest>(
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