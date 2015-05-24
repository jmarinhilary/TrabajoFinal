using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain;
using System.Data.Entity;
using System.Linq.Expressions;
using OnlineShop.Fx.Util;


namespace OnlineShop.Repositories
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : EntityBase
        where TContext : DbContext
    {
        protected TContext Context;

        public RepositoryBase(TContext context)
        {
            this.Context = context;
        }
        public int Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IQueryable<TEntity> Get()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public void Update(TEntity entity, Expression<Func<TEntity, object>>[] properties,
            Expression<Func<TEntity, bool>> predicateExpression)
        {
            TEntity modelEntity = this.Context.Set<TEntity>().AsQueryable().Where(predicateExpression).FirstOrDefault();
            Type modelType = typeof(TEntity);
            foreach (var property in properties)
            {
                string propertyName = property.GetMemberName();
                var propertyValue = modelType.GetProperty(propertyName).GetValue(entity);
                modelType.GetProperty(propertyName).SetValue(modelEntity, propertyValue);
            }
            this.Context.SaveChanges();
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicateExpression)
        {
            return Context.Set<TEntity>().AsQueryable().Where(predicateExpression);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicateExpression)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context = null;
        }
        
    }
}
