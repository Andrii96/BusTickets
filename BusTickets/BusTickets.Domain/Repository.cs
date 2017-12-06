using BusTickets.Domain.Abstract;
using BusTickets.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTickets.Domain
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Fields
            private DbContext _dbContext;
            protected readonly DbSet<T> _dbSet;
        #endregion

        #region Constructor

        public Repository(DbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        #endregion

        #region Implementation

        public void Create(T item)
        {
            _dbSet.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
            _dbContext.SaveChanges();
        }

        public T FindById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public T GetSingleItem(Func<T, bool> predicate)
        {
           return _dbSet.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public void Update(T item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetWithInclude(Func<IQueryable<T>, IQueryable<T>> func)
        {
            return func(_dbSet.AsNoTracking()).ToList();
        }

        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate, Func<IQueryable<T>, IQueryable<T>> func)
        {
            var list = func(_dbSet.AsNoTracking()).ToList();
            return list.Where(predicate).ToList();
        }

        #endregion

    }
}
