using Altos.Api.Framework.Infrastructure;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Altos.Api.Framework.Configuration
{
    public static class AutofacConfig
    {
        public static IContainer Container { get; private set; }

        public static IContainer Initialize(IServiceCollection services)
        {
            //Now register our services with Autofac container
            var containerBuilder = new ContainerBuilder();

            //Register all repositories and services
            containerBuilder.RegisterModule(new DependencyRegistrarModule());

            containerBuilder.Populate(services);

            Container = containerBuilder.Build();

            return Container;
        }
    }
}
