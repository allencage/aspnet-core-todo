using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository.EF.Core
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Checks to see if the entity is null and if not adds it to the context. Make sure to call commit to save the data in the db.
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="callback">Can be used to retrieve the exception using a delegate that takes an Exception as a paramenter.</param>
        void Add(T entry, Action<Exception> callback = null);
        /// <summary>
        /// Checks to see if the list is null or if the list is empty and if not adds the entities to the context. Make sure to call commit.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="callback">Can be used to retrieve the exception using a delegate that takes an Exception as a paramenter.</param>
        void AddRange(IEnumerable<T> list, Action<Exception> callback = null);
        /// <summary>
        /// Updates the entity in the datacontext.
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="callback">Can be used to retrieve the exception using a delegate that takes an Exception as a paramenter.</param>
        void Update(T entry, Action<Exception> callback = null);
        /// <summary>
        /// Get entity by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="callback">Can be used to retrieve the exception using a delegate that takes an Exception as a paramenter.</param>
        /// <returns></returns>
        T Get(long id, Action<Exception> callback = null);
        /// <summary>
        /// Gets all the entities in the db.
        /// </summary>
        /// <param name="callback">Can be used to retrieve the exception using a delegate that takes an Exception as a paramenter.</param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Action<Exception> callback = null);
        /// <summary>
        /// Deletes the entry that is specified.
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="callback">Can be used to retrieve the exception using a delegate that takes an Exception as a paramenter.</param>
        void Delete(T entry, Action<Exception> callback = null);
        /// <summary>
        /// Deletes the entry by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="callback">Can be used to retrieve the exception using a delegate that takes an Exception as a paramenter.</param>
        void Delete(long id, Action<Exception> callback = null);
        /// <summary>
        /// Find a specific entity by a predicate
        /// </summary>
        /// <param name="predicate">Can be used to retrieve the exception using a delegate that takes an Exception as a paramenter.</param>
        /// <returns></returns>
        T Find(Func<T, bool> predicate);
        /// <summary>
        /// Commits the changes to the database
        /// </summary>
        /// <param name="callback">Can be used to retrieve the exception using a delegate that takes an Exception as a paramenter.</param>
        void Commit(Action<Exception> callback = null);
    }
}