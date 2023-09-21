using Intento2Crud.Core.Application.Interfaces;
using Intento2Crud.Core.Domain.Entities;
using Intento2Crud.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Intento2Crud.Infrastructure.Persistence.Repositories
{
    public class PokemonRepository : GenericRepository<Pokemon>, IPokemonRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokemonRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PokemonView?> SPGetAllPokemonsWithIncludeAsync()
        {
            var result = _dbContext.PokemonView.FromSqlRaw("spSelectAllPokemonsJoin").AsEnumerable();

            return result;
        }

        public IEnumerable<object?> GetAllPokemonsWithExcludeAsync() //PROJECTION / AVOIDING CYCLES ERRORS
        {

            var result = _dbContext.Pokemons
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    Region = new { c.Region.Id, c.Region.Name },
                    PrimaryType = new { c.PrimaryType.Id, c.PrimaryType.Name },
                    SecondaryType = new { c.SecondaryType.Id, c.SecondaryType.Name },
                }
            ).AsEnumerable();


            return result;
        }


    }
}
