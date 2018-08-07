using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ChampionsLeague.Configuration
{
    public static class IoCConfiguration
    {
        public static IContainer CreateIoCContainer()
        {
            var builder = new ContainerBuilder();

            ConfigureWebApi(builder);

            RegisterDependencies(builder);

            return builder.Build();
        }

        private static void ConfigureWebApi(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder
                .RegisterType<AutofacWebApiDependencyResolver>()
                .As<System.Web.Http.Dependencies.IDependencyResolver>()
                .SingleInstance();
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {

        }
        }
}