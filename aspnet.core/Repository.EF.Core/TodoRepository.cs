using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Repository.EF.Core.Models;

namespace Repository.EF.Core
{
    public class TodoRepository : Repository<Todo>
    {
        //private readonly DataModel _context;

        public TodoRepository(DataModel context) : base(context)
        {
            if (Entities.Count() == 0)
                SeedData();
            Commit();
        }

        private void SeedData()
        {
            var list = new List<Todo>
            {
                new Todo{Content = "First todo", IsCompleted = false},
                new Todo{Content = "Second todo", IsCompleted = false},
                new Todo{Content = "Third todo", IsCompleted = false},
                new Todo{Content = "Forth todo", IsCompleted = false},
                new Todo{Content = "Fifth todo", IsCompleted = false}
            };
            AddRange(list);
        }

        //public TodoRepository(DataModel context)
        //{
        //    _context = context;
        //    if (_context.TodoItems.Count() == 0)
        //        Add(new Todo { Content = "First Todo", IsCompleted = false });
        //}

        //public void Add(Todo entry, Action<Exception> ex = null)
        //{
        //    _context.Add(entry);
        //    _context.SaveChanges();
        //}

        //public void Commit(Action<Exception> ex = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(Todo entry)
        //{
        //    _context.TodoItems.Remove(entry);
        //    _context.SaveChanges();
        //}

        //public Todo Find(Func<Todo, bool> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public Todo Get(long id, Action<Exception> ex = null)
        //{
        //    return _context.TodoItems.Find(id);
        //}

        //public IEnumerable<Todo> GetAll(Action<Exception> ex = null)
        //{
        //    return _context.TodoItems.AsEnumerable();
        //}

        //public void Update(Todo entry)
        //{
        //    _context.Update(entry);
        //    _context.SaveChanges();
        //}
    }
}
