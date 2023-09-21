using Intento2Crud.Core.Application.Interfaces;
using Intento2Crud.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Intento2Crud.Core.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services) 
        {

            #region services
            services.AddTransient<IRegionService, RegionService>();
            services.AddTransient<IPokemonTypeService, PokemonTypeService>();
            services.AddTransient<IPokemonService, PokemonService>();
            #endregion

            return services;
        }
    }
}