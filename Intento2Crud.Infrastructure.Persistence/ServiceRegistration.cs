using Intento2Crud.Core.Application.Interfaces;
using Intento2Crud.Infrastructure.Persistence.Contexts;
using Intento2Crud.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Intento2Crud.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceInfrasturcture(this IServiceCollection services, IConfiguration config) 
        {
            services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                    m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            });

            #region repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPokemonRepository, PokemonRepository>();
            #endregion

            return services;
        }
    }
}