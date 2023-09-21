using Intento2Crud.Core.Application.Interfaces;
using Intento2Crud.Core.Domain.Common;
using Intento2Crud.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Intento2Crud.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : AuditableBaseEntity
    {
        private readonly ApplicationContext _dbContext;

        public GenericRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Entity> GetAllEnumerable()
        {
            return _dbContext.Set<Entity>().AsEnumerable();
        }

        public async Task<List<Entity>> GetAllAsyncList()
        {
            return await _dbContext.Set<Entity>().ToListAsync();
        }

        public async Task<Entity?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Entity>().FindAsync(id);
        }

        public async Task<Entity> AddAsync(Entity entity)
        {
            entity.Created = DateTime.UtcNow;
            entity.CreatedBy = "Generic User";

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Entity?> UpdateAsync(int id, Entity entity)
        {
            var entityToUpdate = await _dbContext.Set<Entity>().FindAsync(id);

            if (entityToUpdate == null) return null;

            entity.Id = entityToUpdate.Id;
            entity.Updated = DateTime.UtcNow;
            entity.UpdatedBy = "Generic User";

            _dbContext.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entityToDelete = await _dbContext.Set<Entity>().FindAsync(id);

            if (entityToDelete == null) return false;

            _dbContext.Remove(entityToDelete);

            return await _dbContext.SaveChangesAsync() > 0;
        }

    }
}
