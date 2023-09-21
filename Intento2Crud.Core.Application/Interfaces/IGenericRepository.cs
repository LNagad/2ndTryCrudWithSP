using Intento2Crud.Core.Domain.Common;

namespace Intento2Crud.Core.Application.Interfaces
{
    public interface IGenericRepository<Entity> where Entity : AuditableBaseEntity
    {
        Task<Entity> AddAsync(Entity entity);
        Task<bool> DeleteAsync(int id);
        Task<List<Entity>> GetAllAsyncList();
        IEnumerable<Entity> GetAllEnumerable();
        Task<Entity?> GetByIdAsync(int id);
        Task<Entity?> UpdateAsync(int id, Entity entity);
    }
}