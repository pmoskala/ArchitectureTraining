using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using SFC.Infrastructure;

namespace SFC.Alerts
{
  public class AutofacAlertsModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(IEventHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(IQueryHandler<,>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      // don't forget to register AlertRepository
      // builder.RegisterType<AlertRepository>().AsImplementedInterfaces();
    }
  }
}
