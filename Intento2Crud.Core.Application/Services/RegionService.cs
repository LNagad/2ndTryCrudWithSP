using Intento2Crud.Core.Application.DTO;
using Intento2Crud.Core.Application.Interfaces;
using Intento2Crud.Core.Domain.Entities;

namespace Intento2Crud.Core.Application.Services
{
    public class RegionService : IRegionService
    {
        private readonly IGenericRepository<Region> _repository;

        public RegionService(IGenericRepository<Region> repository)
        {
            _repository = repository;
        }

        public List<RegionDTO> GetAll()
        {
            var regions = _repository.GetAllEnumerable();

            var regionsDTO = regions.Select(x => new RegionDTO()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return regionsDTO;
        }


        public async Task<RegionDTO?> GetByIdAsync(int id)
        {
            var region = await _repository.GetByIdAsync(id);
            if (region == null) return null;
            var regionDTO = new RegionDTO() { Id = region.Id, Name = region.Name };

            return regionDTO;
        }

        public async Task<RegionDTO> AddAsync(RegionDTO RegionDTO)
        {
            Region region = new() { Name = RegionDTO.Name };

            await _repository.AddAsync(region);

            RegionDTO.Id = region.Id;

            return RegionDTO;
        }

        public async Task<RegionDTO?> UpdateAsync(int id, RegionDTO RegionDTO)
        {
            Region region = new() { Name = RegionDTO.Name };

            await _repository.UpdateAsync(id, region);

            RegionDTO.Id = region.Id;

            return RegionDTO;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
