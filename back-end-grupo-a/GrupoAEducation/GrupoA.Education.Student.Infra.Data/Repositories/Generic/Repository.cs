using GrupoA.Education.Student.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GrupoA.Education.Student.Domain.Generic.Entities;

namespace GrupoA.Education.Student.Infra.Data.Repositories.Generic
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : BaseEntity where TContext : DbContext
    {
        protected readonly TContext _context;
    
        public Repository(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            return await query.FirstOrDefaultAsync(e => e.PrimaryKey == id);
        }

        public async Task<TEntity> GetByIdAsNoTracking(Guid id)
        {
            var query = _context.Set<TEntity>().AsQueryable().AsNoTracking();
            return await query.FirstOrDefaultAsync(e => e.PrimaryKey == id);
        }

        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _context
                .Set<TEntity>()
                .AsNoTracking();

            return query;
        }

        public async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity, bool destroy = false)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context
                .Set<TEntity>()
                .AsNoTracking()
                .AnyAsync(predicate);
        }
        
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context
                .Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }        
    }
}