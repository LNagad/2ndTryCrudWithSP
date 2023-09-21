using Intento2Crud.Core.Application.DTO;
using Intento2Crud.Core.Application.Interfaces;
using Intento2Crud.Core.Domain.Entities;

namespace Intento2Crud.Core.Application.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IGenericRepository<Pokemon> _repository;
        private readonly IGenericRepository<PokemonType> _pokemonTypeRepository;
        private readonly IGenericRepository<Region> _regionRepository;

        public PokemonService(
            IGenericRepository<Pokemon> repository,
            IGenericRepository<PokemonType> pokemonTypeRepository,
            IGenericRepository<Region> regionRepository)
        {
            _repository = repository;
            _pokemonTypeRepository = pokemonTypeRepository;
            _regionRepository = regionRepository;
        }

        public List<PokemonDTO> GetAll()
        {
            var Pokemons = _repository.GetAllEnumerable();

            var PokemonsDTO = Pokemons.Select(x => new PokemonDTO()
            {
                Id = x.Id,
                Name = x.Name,
                PhotoUrl = x.PhotoUrl,
                PrimaryTypeId = x.PrimaryTypeId,
                SecondaryTypeId = x.SecondaryTypeId,
                RegionId = x.RegionId
            }).ToList();

            return PokemonsDTO;
        }


        public async Task<PokemonDTO?> GetByIdAsync(int id)
        {
            var Pokemon = await _repository.GetByIdAsync(id);

            if (Pokemon == null) return null;

            var PokemonDTO = new PokemonDTO()
            {
                Id = Pokemon.Id,
                Name = Pokemon.Name,
                PhotoUrl = Pokemon.PhotoUrl,
                PrimaryTypeId = Pokemon.PrimaryTypeId,
                SecondaryTypeId = Pokemon.SecondaryTypeId,
                RegionId = Pokemon.RegionId
            };

            return PokemonDTO;
        }

        public async Task<PokemonDTO?> AddAsync(PokemonDTO PokemonDTO)
        {
            var primaryTypeExist = await _pokemonTypeRepository.GetByIdAsync(PokemonDTO.PrimaryTypeId);

            if (primaryTypeExist == null) return null;

            if (PokemonDTO.SecondaryTypeId != 0)
            {
                var secondaryTypeExist = await _pokemonTypeRepository.GetByIdAsync(PokemonDTO.SecondaryTypeId);

                if (secondaryTypeExist == null) return null;
            }

            var regionExist = await _regionRepository.GetByIdAsync(PokemonDTO.RegionId);

            if (regionExist == null) return null;

            Pokemon Pokemon = new()
            {
                Name = PokemonDTO.Name,
                PhotoUrl = PokemonDTO.PhotoUrl,
                PrimaryTypeId = PokemonDTO.PrimaryTypeId,
                SecondaryTypeId = PokemonDTO.SecondaryTypeId,
                RegionId = PokemonDTO.RegionId
            };

            await _repository.AddAsync(Pokemon);

            PokemonDTO.Id = Pokemon.Id;

            return PokemonDTO;
        }

        public async Task<PokemonDTO?> UpdateAsync(int id, PokemonDTO PokemonDTO)
        {
            var primaryTypeExist = await _pokemonTypeRepository.GetByIdAsync(PokemonDTO.PrimaryTypeId);

            if (primaryTypeExist == null) return null;

            if (PokemonDTO.SecondaryTypeId != 0)
            {
                var secondaryTypeExist = await _pokemonTypeRepository.GetByIdAsync(PokemonDTO.SecondaryTypeId);

                if (secondaryTypeExist == null) return null;
            }

            var regionExist = await _regionRepository.GetByIdAsync(PokemonDTO.RegionId);

            if (regionExist == null) return null;

            Pokemon pokemon = new()
            {
                Id = PokemonDTO.Id,
                Name = PokemonDTO.Name,
                PhotoUrl = PokemonDTO.PhotoUrl,
                PrimaryTypeId = PokemonDTO.PrimaryTypeId,
                SecondaryTypeId = PokemonDTO.SecondaryTypeId,
                RegionId = PokemonDTO.RegionId
            };

            await _repository.UpdateAsync(id, pokemon);

            return PokemonDTO;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
