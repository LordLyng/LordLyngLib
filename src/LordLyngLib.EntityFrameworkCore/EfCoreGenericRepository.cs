using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using LordLyngLib.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LordLyngLib.EntityFrameworkCore
{
    public class EfCoreGenericRepository<TEntity> : IAsyncGenericRepository<TEntity>, ISychornousGenericRepository<TEntity>
        where TEntity : class
        {
            private readonly DbContext _dbContext;

            public EfCoreGenericRepository (DbContext dbContext)
            {
                _dbContext = dbContext;
            }

            private DbSet<TEntity> Set => _dbContext.Set<TEntity> ();

            public TEntity FindById (object id)
            {
                return Set.Find (id);
            }

            public async Task<TEntity> FindByIdAsync (object id, CancellationToken cancellationToken = default)
            {
                return await Set.FindAsync (new [] { id }, cancellationToken);
            }

            public TEntity Create (TEntity entity)
            {
                Set.Add (entity);
                _dbContext.SaveChanges ();
                return entity;
            }

            public async Task<TEntity> CreateAsync (TEntity entity, CancellationToken cancellationToken = default)
            {
                await Set.AddAsync (entity, cancellationToken);
                await _dbContext.SaveChangesAsync (cancellationToken);
                return entity;
            }

            public IEnumerable<TEntity> CreateRange (params TEntity[] entities)
            {
                Set.AddRange (entities);
                _dbContext.SaveChanges ();
                return entities;
            }

            public async Task<IEnumerable<TEntity>> CreateRangeAsync (CancellationToken cancellationToken = default, params TEntity[] entities)
            {
                await Set.AddRangeAsync (entities, cancellationToken);
                await _dbContext.SaveChangesAsync (cancellationToken);
                return entities;
            }

            public IEnumerable<TEntity> Find (Expression<Func<TEntity, bool>> filter, int? skip = null, int? take = null, Expression<Func<TEntity, object>> orderBy = null)
            {
                var query = Set.AsQueryable ();

                query = query.Where (filter);

                if (orderBy != null)
                    query = query.OrderBy (orderBy);

                if (skip.HasValue)
                    query = query.Skip (skip.Value);

                if (take.HasValue)
                    query = query.Take (take.Value);

                return query.ToList ();
            }

            public async Task<IEnumerable<TEntity>> FindAsync (Expression<Func<TEntity, bool>> filter, int? skip = null, int? take = null, Expression<Func<TEntity, object>> orderBy = null, CancellationToken cancellationToken = default)
            {
                var query = Set.AsQueryable ();

                query = query.Where (filter);

                if (orderBy != null)
                    query = query.OrderBy (orderBy);

                if (skip.HasValue)
                    query = query.Skip (skip.Value);

                if (take.HasValue)
                    query = query.Take (take.Value);

                return await query.ToListAsync (cancellationToken);
            }

            public TEntity Update (TEntity entity)
            {
                Set.Update (entity);
                _dbContext.SaveChanges ();
                return entity;
            }

            public async Task<TEntity> UpdateAsync (TEntity entity, CancellationToken cancellationToken = default)
            {
                Set.Update (entity);
                await _dbContext.SaveChangesAsync (cancellationToken);
                return entity;
            }

            public IEnumerable<TEntity> UpdateRange (params TEntity[] entities)
            {
                Set.UpdateRange (entities);
                _dbContext.SaveChanges ();
                return entities;
            }

            public async Task<IEnumerable<TEntity>> UpdateRangeAsync (CancellationToken cancellationToken = default, params TEntity[] entities)
            {
                Set.UpdateRange (entities);
                await _dbContext.SaveChangesAsync (cancellationToken);
                return entities;
            }

            public void Delete (TEntity entity)
            {
                Set.Remove (entity);
                _dbContext.SaveChanges ();
            }

            public async Task DeleteAsync (TEntity entity, CancellationToken cancellationToken = default)
            {
                Set.Remove (entity);
                await _dbContext.SaveChangesAsync (cancellationToken);
            }

            public void DeleteRange (params TEntity[] entities)
            {
                Set.RemoveRange (entities);
                _dbContext.SaveChanges ();
            }

            public async Task DeleteRangeAsync (CancellationToken cancellationToken = default, params TEntity[] entities)
            {
                Set.RemoveRange (entities);
                await _dbContext.SaveChangesAsync (cancellationToken);
            }
        }
}
