using easydd.core.interfaces;
using easydd.core.interfaces.repository;
using easydd.core.model;
using easydd.infrastructure.repository;
using Microsoft.Extensions.DependencyInjection;

namespace easydd.infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ILootChanceRepository, LootChanceRepository>();
            services.AddScoped<ILootRepository, LootRepository>();
            services.AddScoped<ILootTableRepository, LootTableRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IRepository<Entity>, BaseRepository<Entity>>();
            return services;
        }
    }
}
