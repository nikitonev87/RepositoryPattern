using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryPattern.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(int id);
        ICollection<T> Get(Expression<Func<T, bool>> where);
    }
}
