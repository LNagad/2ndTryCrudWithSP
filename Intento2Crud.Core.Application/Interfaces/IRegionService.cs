using Intento2Crud.Core.Application.DTO;

namespace Intento2Crud.Core.Application.Interfaces
{
    public interface IRegionService
    {
        Task<RegionDTO> AddAsync(RegionDTO RegionDTO);
        Task<bool> DeleteAsync(int id);
        List<RegionDTO> GetAll();
        Task<RegionDTO?> GetByIdAsync(int id);
        Task<RegionDTO?> UpdateAsync(int id, RegionDTO RegionDTO);
    }
}