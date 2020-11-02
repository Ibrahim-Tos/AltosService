using System;
using Altos.Api.Framework.Configuration;
using Altos.Api.Framework.Infrastructure;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Altos.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Authentication configuration
            
            AuthenticationConfig.Initialize(services);

            // Enable and configure Swagger / Swashbuckle
            SwaggerConfig.Initialize(services, GetXmlCommentsPath());

            // Autofac container
            var container = AutofacConfig.Initialize(services);

            //Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        }

        /// <summary>
        /// ConfigureContainer is where you can register things directly
        /// with Autofac. This runs after ConfigureServices so the things
        /// here will override registrations made in ConfigureServices.
        /// Don't build the container; that gets done for you by the factory.
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DependencyRegistrarModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure Web API
            var config = WebApiConfig.Initialize();

            //app.ConfigureRequestPipeline();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMvc();

            // Start Swagger / Swashbuckle
            SwaggerConfig.Start(app);
        }

        private string GetXmlCommentsPath()
        {
            var baseDirectoryPath = AppContext.BaseDirectory;
            // Setting xml comments to be saved by right-click on the project -> properties and navigate to the build tab. On this tab, check "XML documentation file" option. see: https://www.talkingdotnet.com/add-swagger-to-asp-net-core-web-api/
            return System.IO.Path.Combine(baseDirectoryPath, "Altos.Api.xml");
        }
    }
}
