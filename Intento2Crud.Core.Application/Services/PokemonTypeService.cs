using Intento2Crud.Core.Application.DTO;
using Intento2Crud.Core.Application.Interfaces;
using Intento2Crud.Core.Domain.Entities;

namespace Intento2Crud.Core.Application.Services
{
    public class PokemonTypeService : IPokemonTypeService
    {
        private readonly IGenericRepository<PokemonType> _repository;

        public PokemonTypeService(IGenericRepository<PokemonType> repository)
        {
            _repository = repository;
        }

        public List<PokemonTypeDTO> GetAll()
        {
            var PokemonTypes = _repository.GetAllEnumerable();

            var PokemonTypesDTO = PokemonTypes.Select(x => new PokemonTypeDTO()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return PokemonTypesDTO;
        }


        public async Task<PokemonTypeDTO?> GetByIdAsync(int id)
        {
            var PokemonType = await _repository.GetByIdAsync(id);
            if (PokemonType == null) return null;
            var PokemonTypeDTO = new PokemonTypeDTO() { Id = PokemonType.Id, Name = PokemonType.Name };

            return PokemonTypeDTO;
        }

        public async Task<PokemonTypeDTO> AddAsync(PokemonTypeDTO PokemonTypeDTO)
        {
            PokemonType PokemonType = new() { Name = PokemonTypeDTO.Name };

            await _repository.AddAsync(PokemonType);

            PokemonTypeDTO.Id = PokemonType.Id;

            return PokemonTypeDTO;
        }

        public async Task<PokemonTypeDTO?> UpdateAsync(int id, PokemonTypeDTO PokemonTypeDTO)
        {
            PokemonType PokemonType = new() { Name = PokemonTypeDTO.Name };

            await _repository.UpdateAsync(id, PokemonType);

            PokemonTypeDTO.Id = PokemonType.Id;

            return PokemonTypeDTO;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
