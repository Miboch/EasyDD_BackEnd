using easydd.core.interfaces;
using easydd.core.model;
using easydd.infrastructure.repository;
using Microsoft.Extensions.DependencyInjection;

namespace easydd.infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IRepository<Entity>, BaseRepository<Entity>>();
            return services;
        }
    }
}
