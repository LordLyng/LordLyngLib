using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace LordLyngLib.Core.Interfaces
{
    public interface IAsyncGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindByIdAsync (object id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FindAsync (Expression<Func<TEntity, bool>> filter, int? skip = null, int? take = null, Expression<Func<TEntity, object>> orderBy = null, CancellationToken cancellationToken = default);
        Task<TEntity> CreateAsync (TEntity entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> CreateRangeAsync (CancellationToken cancellationToken = default, params TEntity[] entities);
        Task<TEntity> UpdateAsync (TEntity entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> UpdateRangeAsync (CancellationToken cancellationToken = default, params TEntity[] entities);
        Task DeleteAsync (TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteRangeAsync (CancellationToken cancellationToken = default, params TEntity[] entities);
    }
}
