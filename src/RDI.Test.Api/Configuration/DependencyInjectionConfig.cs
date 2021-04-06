using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RDI.Test.Api.Extensions;
using RDI.Test.Application.Interfaces;
using RDI.Test.Application.Notifications;
using RDI.Test.Application.Services;
using RDI.Test.Infra.Context;
using RDI.Test.Infra.Interfaces;
using RDI.Test.Infra.Repository;

namespace RDI.Test.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            return services;
        }
    }
}