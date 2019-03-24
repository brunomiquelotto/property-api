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
        protected readonly ApplicationContext Context;
        protected DbSet<TEntity> DbSet;

        public Repository(ApplicationContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        public void Delete(params object[] keyValues)
        {
            DbSet.Remove(this.Find(keyValues));
            Context.SaveChanges();
        }

        public TEntity Find(params object[] keyValues)
        {
            return DbSet.Find(keyValues);
        }

        public IEnumerable<TEntity> Get(Expression<System.Func<TEntity, bool>> expression = null)
        {
            if (expression != null)
            {
                return DbSet.Where(expression).ToList();
            }
            return DbSet.ToList();
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
