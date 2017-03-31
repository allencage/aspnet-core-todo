using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository.EF.Core
{
    public interface IRepository<T> where T : class
    {
        void Add(T entry, Action<Exception> ex = null);
        void Update(T entry);
        T Get(long id, Action<Exception> ex = null);
        IEnumerable<T> GetAll(Action<Exception> ex = null);
        void Delete(T entry);
        T Find(Func<T, bool> predicate);
        void Commit(Action<Exception> ex = null);
    }
}