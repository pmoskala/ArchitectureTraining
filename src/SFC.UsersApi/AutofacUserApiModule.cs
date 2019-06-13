﻿using Autofac;
using SFC.Infrastructure;
using SFC.UserApi.Alerts;

namespace SFC.UserApi
{
    public class AutofacUserApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AlertRepository>().As<IAlertRepository>().InstancePerLifetimeScope();

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
