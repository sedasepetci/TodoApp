using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Core.Repositories;

public class EfRepositoryBase<TContext, TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>, new()
    where TContext : DbContext
{

   
        protected TContext Context { get; }

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

       
        public async Task<TEntity?> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool enableAutoInclude = true)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!enableAutoInclude)
            {
                query = query.IgnoreAutoIncludes();
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

       
        public async Task<TEntity?> RemoveAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

       
        public async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
    }


