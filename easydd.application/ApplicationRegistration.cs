using easydd.application.services;
using easydd.core.interfaces;
using easydd.core.interfaces.service;
using easydd.core.model;
using Microsoft.Extensions.DependencyInjection;

namespace easydd.application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<IEasyImageService, EasyImageService>();
            services.AddScoped<IEasyImageTagService, EasyImageTagService>();
            services.AddScoped<ILootService, LootService>();
            services.AddScoped<ILootChanceService, LootChanceService>();
            services.AddScoped<ILootTableService, LootTableService>();
            services.AddScoped<IService<Entity>, BaseService<Entity>>();
            services.AddScoped<ITagService, TagService>();
            return services;
        }
    }
}
