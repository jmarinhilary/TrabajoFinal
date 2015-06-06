using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain;
using System.Data.Entity;
using System.Linq.Expressions;
using OnlineShop.Fx.Util;
using System.Data.Entity.Validation;


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
            //try
            //{
            Context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    var newException = new FormattedDbEntityValidationException(e);
            //    throw newException;
            //}

            return entity.Id;
        }

        public int Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges();            
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

    //public class FormattedDbEntityValidationException : Exception
    //{
    //    public FormattedDbEntityValidationException(DbEntityValidationException innerException) :
    //        base(null, innerException)
    //    {
    //    }

    //    public override string Message
    //    {
    //        get
    //        {
    //            var innerException = InnerException as DbEntityValidationException;
    //            if (innerException != null)
    //            {
    //                StringBuilder sb = new StringBuilder();

    //                sb.AppendLine();
    //                sb.AppendLine();
    //                foreach (var eve in innerException.EntityValidationErrors)
    //                {
    //                    sb.AppendLine(string.Format("- Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
    //                        eve.Entry.Entity.GetType().FullName, eve.Entry.State));
    //                    foreach (var ve in eve.ValidationErrors)
    //                    {
    //                        sb.AppendLine(string.Format("-- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
    //                            ve.PropertyName,
    //                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
    //                            ve.ErrorMessage));
    //                    }
    //                }
    //                sb.AppendLine();

    //                return sb.ToString();
    //            }

    //            return base.Message;
    //        }
    //    }
    //}
}
