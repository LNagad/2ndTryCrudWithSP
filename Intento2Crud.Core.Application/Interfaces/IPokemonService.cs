using Intento2Crud.Core.Application.DTO;

namespace Intento2Crud.Core.Application.Interfaces
{
    public interface IPokemonService
    {
        Task<PokemonDTO?> AddAsync(PokemonDTO PokemonDTO);
        Task<bool> DeleteAsync(int id);
        List<PokemonDTO> GetAll();
        Task<PokemonDTO?> GetByIdAsync(int id);
        Task<PokemonDTO?> UpdateAsync(int id, PokemonDTO PokemonDTO);
    }
}