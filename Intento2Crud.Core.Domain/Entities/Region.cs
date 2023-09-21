using Intento2Crud.Core.Domain.Common;

namespace Intento2Crud.Core.Domain.Entities
{
    public class Region : AuditableBaseEntity
    {
        public required string Name { get; set; }
        public ICollection<Pokemon>? Pokemons { get; }
    }
}
