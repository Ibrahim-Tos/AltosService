using Altos.Api.Framework.Infrastructure.Authorization;
using Altos.Data.Features.Orders;
using Altos.Data.Features.Products;
using Altos.Data.Features.Users;
using Altos.Services.Features.Authentication;
using Altos.Services.Features.Products;
using Altos.Services.Features.Users;
using Altos.Util.Dependency;
using Altos.Util.Helpers;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Altos.Api.Framework.Infrastructure
{
    public class DependencyRegistrarModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //data layer
            builder.RegisterType<OrderCache>().As<IOrderCache>().InstancePerLifetimeScope();
            builder.RegisterType<OrderItemCache>().As<IOrderItemCache>().InstancePerLifetimeScope();
            builder.RegisterType<ProductCache>().As<IProductCache>().InstancePerLifetimeScope();
            builder.RegisterType<ProductInstanceCache>().As<IProductInstanceCache>().InstancePerLifetimeScope();
            builder.RegisterType<UserCache>().As<IUserCache>().InstancePerLifetimeScope();

            //IMapper
            var typeFinder = new TypeFinder();
            builder.RegisterType<ActionContextAccessor>().As<IActionContextAccessor>().InstancePerLifetimeScope();
            var mapperConfig = new MapperConfiguration((config) => { config.AddProfile(new AutoMapperDynamicMapProfile(typeFinder)); });
            var mapper = new Mapper(mapperConfig);

            builder.RegisterInstance<IMapper>(mapper);

            //Authorization
            builder.RegisterType<AltosAuthorizationFilter>().As<IAuthorizationFilter>().InstancePerLifetimeScope();
            builder.RegisterType<AltosAuthorizationAttribute>().As<TypeFilterAttribute>().InstancePerLifetimeScope();

            //services
            builder.RegisterType<ActionContextAccessor>().As<IActionContextAccessor>().InstancePerLifetimeScope();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductInstanceService>().As<IProductInstanceService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
        }
    }
}
