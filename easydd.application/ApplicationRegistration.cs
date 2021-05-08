using easydd.application.services;
using easydd.core.interfaces;
using easydd.core.model;
using Microsoft.Extensions.DependencyInjection;

namespace easydd.application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<IService<Entity>, BaseService<Entity>>();
            services.AddScoped<ITagService, TagService>();
            return services;
        }
    }
}
