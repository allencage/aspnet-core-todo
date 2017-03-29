using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository.EF.Core
{
    public interface IRepository<T> where T : class
    {
        void Add(T entry);
        void Update(T entry);
        T Get(long id);
        IEnumerable<T> GetAll();
        void Delete(T entry);
        void Find(Expression<Func<T, bool>> predicate);
        void Commit();
    }
}