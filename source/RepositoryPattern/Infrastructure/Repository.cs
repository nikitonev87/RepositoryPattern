using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryPattern.Infrastructure
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext context;
        protected DbSet<T> DbSet { get; private set; }

        public Repository(MyDbContext context)
        {
            this.context = context;
            this.DbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }
        public virtual T Get(int id)
        {
            return DbSet.Find(id);
        }
        public virtual ICollection<T> Get(Expression<Func<T, bool>> where)
        {
            return DbSet.Where(where).ToList();
        }
    }
}
