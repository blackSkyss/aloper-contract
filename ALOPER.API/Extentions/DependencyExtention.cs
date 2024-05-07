using ALOPER.Repository.Infrastructures;
using ALOPER.Service.Services.Implements;
using ALOPER.Service.Services.Interfaces;
using MBKC.API.Extentions;
using MBKC.API.Middlewares;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ALOPER.API.Extentions
{
    public static class DependencyExtention
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddDbFactory(this IServiceCollection services)
        {
            services.AddScoped<IDbFactory, DbFactory>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IContractService, ContractService>();
            return services;
        }

        public static IServiceCollection AddExceptionMiddleware(this IServiceCollection services)
        {
            services.AddTransient<ExceptionMiddleware>();
            return services;
        }

        public static IServiceCollection AddConfigSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ALOPER Application API",
                    Description = "The ALOPER Application API is built for the management contract."
                });
                

            });
            return services;
        }

        public static WebApplication AddApplicationConfig(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("WebPolicy");
            //Add middleware extentions
            app.ConfigureExceptionMiddleware();
            app.MapControllers();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NBaF5cXmZCeExzWmFZfVpgdVdMYFtbR3VPMyBoS35RckVmWXlccnRTRmVeU0V0");
            return app;
        }

    }
}
