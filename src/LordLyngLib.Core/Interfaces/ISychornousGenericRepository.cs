using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LordLyngLib.Core.Interfaces
{
    public interface ISychornousGenericRepository<TEntity> where TEntity : class
    {
        TEntity FindById (object id);
        IEnumerable<TEntity> Find (Expression<Func<TEntity, bool>> filter, int? skip = null, int? take = null, Expression<Func<TEntity, object>> orderBy = null);
        TEntity Create (TEntity entity);
        IEnumerable<TEntity> CreateRange (params TEntity[] entities);
        TEntity Update (TEntity entity);
        IEnumerable<TEntity> UpdateRange (params TEntity[] entities);
        void Delete (TEntity entity);
        void DeleteRange (params TEntity[] entities);
    }
}
