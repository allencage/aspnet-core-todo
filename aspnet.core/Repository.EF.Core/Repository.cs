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
        public void Add(T entry)
        {
            try
            {
                if (entry == null)
                    throw new ArgumentNullException("entry");
                Entities.Add(entry);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(T entry)
        {
            throw new NotImplementedException();
        }

        public void Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Get(long id)
        {
            try
            {
                var result = Entities.Find(id);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(T entry)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                var results = Entities.AsEnumerable();
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
