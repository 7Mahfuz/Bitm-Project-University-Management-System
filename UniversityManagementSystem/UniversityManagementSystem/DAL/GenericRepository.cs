using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class GenericRepository<T> : _IGenericRepository<T> where T : class
    {

        private ApplicationDbContext context;
        private DbSet<T> _DbSet;

        public GenericRepository(ApplicationDbContext _context)
        {
            context = _context;
            this._DbSet = _context.Set<T>();
        }

        public int Count(Func<T, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public bool DeleteModel(T model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetList(Func<T, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public T GetModel(Func<T, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public T GetModelById(int ModelId)
        {
            throw new NotImplementedException();
        }

        public bool InsertModel(T model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateModel(T model)
        {
            throw new NotImplementedException();
        }
    }
}