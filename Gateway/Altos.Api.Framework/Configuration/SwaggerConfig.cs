using System;
using Altos.Api.Framework.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Altos.Api.Framework.Configuration
{
    public class SwaggerConfig
    {
        public static void Initialize(IServiceCollection services, string xmlCommentsPath)
        {
            // Enable and configure Swagger / Swashbuckle
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Altos API",
                    Description = "Altos ASP.NET Core 3.0 Web API",
                    TermsOfService = new Uri("https://altos.com/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Altos",
                        Email = "info@altos.com",
                        Url = new Uri("https://altos.com/")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                // Include actions comment in swagger ui
                c.IncludeXmlComments(xmlCommentsPath, true);
            });

            services.ConfigureSwaggerGen(options =>
            {
                options.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });
        }

        public static void Start(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Altos Gateway");
            });
        }
    }
}
