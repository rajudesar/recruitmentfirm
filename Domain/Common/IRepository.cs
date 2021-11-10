using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Common
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void AddOrUpdate(Expression<Func<TEntity, object>> identifierExpression, TEntity entity);
        TEntity GetById(TKey id);
        TEntity FirstOrDefault();
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression);
    }
}
