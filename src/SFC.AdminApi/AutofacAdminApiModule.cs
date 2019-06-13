using Autofac;
using SFC.AdminApi.Dashboard;
using SFC.AdminApi.SearchableDashboard;
using SFC.Infrastructure;

namespace SFC.AdminApi
{
  public class AutofacAdminApiModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<DashboardPerspective>()
        .AsImplementedInterfaces();

      builder.RegisterType<SearchableDashboardPerspective>()
        .AsImplementedInterfaces();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(IEventHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(IQueryHandler<,>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    }
  }
}
