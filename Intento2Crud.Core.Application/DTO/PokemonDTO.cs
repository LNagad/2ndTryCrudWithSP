namespace Intento2Crud.Core.Application.DTO
{
    public class PokemonDTO
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string PhotoUrl { get; set; }

        public required int RegionId { get; set; }
        public required int PrimaryTypeId { get; set; }
        public int SecondaryTypeId { get; set; }
    }
}
