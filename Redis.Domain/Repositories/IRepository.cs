using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Redis.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(params object[] keyValues);
        TEntity Find(params object[] keyValues);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression = null);
    }
}
