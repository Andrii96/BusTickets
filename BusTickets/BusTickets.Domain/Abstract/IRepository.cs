using BusTickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTickets.Domain.Abstract
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        IEnumerable<T> GetWithInclude(Func<IQueryable<T>, IQueryable<T>> func);
        IEnumerable<T> GetWithInclude(Func<T, bool> predicate, Func<IQueryable<T>, IQueryable<T>> func);
        T GetSingleItem(Func<T, bool> predicate);
        T FindById(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);

    }
}
