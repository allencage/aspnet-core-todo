using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.EF.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _context;
        private DbSet<T> _entities;
        public DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
        public Repository(DbContext context)
        {
            _context = context;
        }
        public void Add(T entry, Action<Exception> callback = null)
        {
            try
            {
                if (entry == null)
                    throw new ArgumentNullException(nameof(entry));
                Entities.Add(entry);
            }
            catch (Exception ex)
            {
                callback?.Invoke(ex);
            }
        }

        public void Delete(T entry, Action<Exception> callback)
        {
            try
            {
                if (entry == null)
                {
                    throw new ArgumentNullException(nameof(entry));
                }
                _context.Remove(entry);
            }
            catch (Exception ex)
            {
                callback?.Invoke(ex);
            }
        }

        public T Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public T Get(long id, Action<Exception> callback = null)
        {
            try
            {
                var result = Entities.Find(id);
                return result;
            }
            catch (Exception ex)
            {
                callback?.Invoke(ex);
            }
            return null;
        }

        public void Update(T entry, Action<Exception> callback = null)
        {
            try
            {
                if (entry == null)
                {
                    throw new ArgumentNullException(nameof(entry));
                }
                Entities.Update(entry);
            }
            catch (Exception ex)
            {
                callback?.Invoke(ex);
            }
        }

        public IEnumerable<T> GetAll(Action<Exception> callback = null)
        {
            try
            {
                var results = Entities.AsEnumerable();
                return results;
            }
            catch (Exception ex)
            {
                callback?.Invoke(ex);
            }
            return new List<T>();
        }

        public void Commit(Action<Exception> callback = null)
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                callback?.Invoke(ex);
            }
        }

        public void AddRange(IEnumerable<T> list, Action<Exception> callback = null)
        {
            if(list == null || !list.Any())
            {
                return;
            }
            foreach (var item in list)
            {
                Add(item);
            }
        }

        public void Delete(long id, Action<Exception> callback = null)
        {
            try
            {
                var entity = Entities.Find(id);
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                Entities.Remove(entity);
            }
            catch (Exception ex)
            {
                callback?.Invoke(ex);
            }
        }
    }
}
