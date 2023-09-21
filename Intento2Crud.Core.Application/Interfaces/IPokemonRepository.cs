using Intento2Crud.Core.Domain.Entities;

namespace Intento2Crud.Core.Application.Interfaces
{
    public interface IPokemonRepository : IGenericRepository<Pokemon>
    {
        IEnumerable<PokemonView?> SPGetAllPokemonsWithIncludeAsync();

        IEnumerable<object?> GetAllPokemonsWithExcludeAsync();
    }
}