using Microsoft.EntityFrameworkCore;
using Redis.Domain.Repositories;
using Redis.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Redis.Infra.Data.Repositories.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppContext context;
        private DbSet<TEntity> dbSet;

        public Repository(AppContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public void Delete(params object[] keyValues)
        {
            dbSet.Remove(this.Find(keyValues));
            context.SaveChanges();
        }

        public TEntity Find(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }

        public IEnumerable<TEntity> Get(Expression<System.Func<TEntity, bool>> expression = null)
        {
            if (expression != null)
            {
                return dbSet.Where(expression).ToList();
            }
            return dbSet.ToList();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
