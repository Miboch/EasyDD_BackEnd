using easydd.application.services;
using easydd.core.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace easydd.application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<ITagService, TagService>();
            return services;
        }
    }
}
