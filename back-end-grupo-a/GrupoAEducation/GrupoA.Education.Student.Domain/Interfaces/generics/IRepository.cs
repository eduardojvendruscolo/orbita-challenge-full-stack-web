using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GrupoA.Education.Student.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<TEntity> GetById(Guid id);
        Task<TEntity> GetByIdAsNoTracking(Guid id);
        IQueryable<TEntity> GetAll();
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity, bool destroy = false);
        Task SaveChanges();
        Task<bool> Exists(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}