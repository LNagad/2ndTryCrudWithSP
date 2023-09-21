using Intento2Crud.Core.Application.DTO;

namespace Intento2Crud.Core.Application.Interfaces
{
    public interface IPokemonTypeService
    {
        Task<PokemonTypeDTO> AddAsync(PokemonTypeDTO PokemonTypeDTO);
        Task<bool> DeleteAsync(int id);
        List<PokemonTypeDTO> GetAll();
        Task<PokemonTypeDTO?> GetByIdAsync(int id);
        Task<PokemonTypeDTO?> UpdateAsync(int id, PokemonTypeDTO PokemonTypeDTO);
    }
}