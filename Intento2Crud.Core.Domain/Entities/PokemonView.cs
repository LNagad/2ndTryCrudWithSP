using Intento2Crud.Core.Domain.Common;

namespace Intento2Crud.Core.Domain.Entities
{
    public class PokemonView : AuditableBaseEntity
    {
        public required string Name { get; set; }

        public required string PhotoUrl { get; set; }

        public required int RegionId { get; set; }
        public required int PrimaryTypeId { get; set; }
        public int? PokemonTypeId { get; set; }
        public int SecondaryTypeId { get; set; }

        public string? RegionName { get; set; }
        public string? PrimaryType { get; set; }
        public string? SecondaryType { get; set; }
    }
}
