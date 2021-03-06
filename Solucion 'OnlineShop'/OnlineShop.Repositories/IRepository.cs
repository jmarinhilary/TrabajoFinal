﻿using System;
using System.Linq;
using OnlineShop.Domain;
using System.Linq.Expressions;

namespace OnlineShop.Repositories
{
    public interface IRepository<T> : IDisposable
        where T : EntityBase
    {
        int Create(T entity);
        IQueryable<T> Get();
        int Update(T entity);
        void Update(T entity, Expression<Func<T, object>>[] properties, Expression<Func<T, bool>> predicateExpression);
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicateExpression);
        void Delete(Expression<Func<T, bool>> predicateExpression);

    }
}
