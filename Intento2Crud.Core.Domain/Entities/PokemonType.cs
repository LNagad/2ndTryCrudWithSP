using Intento2Crud.Core.Domain.Common;

namespace Intento2Crud.Core.Domain.Entities
{
    public class PokemonType : AuditableBaseEntity
    {
        public required string Name { get; set; }
        public ICollection<Pokemon>? Pokemons { get;}
    }
}
