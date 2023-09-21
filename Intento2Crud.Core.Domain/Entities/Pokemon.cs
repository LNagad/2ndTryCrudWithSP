using Intento2Crud.Core.Domain.Common;

namespace Intento2Crud.Core.Domain.Entities
{
    public class Pokemon : AuditableBaseEntity
    {
        public required string Name { get; set; }

        public required string PhotoUrl { get; set; }

        public required int RegionId { get; set; }
        public required int PrimaryTypeId { get; set; }
        public int SecondaryTypeId { get; set; }

        public Region? Region { get; set; }
        public PokemonType? PrimaryType { get; set; }
        public PokemonType? SecondaryType { get; set; }
    }
}
