using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            if (predicate == null)
            {
                int x = _DbSet.Count();
                return x;
            }
            else
            {
                int x = _DbSet.Count(predicate);
                return x;
            }

        }

        public bool DeleteModel(T model)
        {

            bool flag = true;
            try
            {
                _DbSet.Attach(model);
                _DbSet.Remove(model);
            }
            catch { flag = false; };

            return flag;
        }

        public IEnumerable<T> GetList(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _DbSet.Where(predicate);
            }
            else return _DbSet.AsEnumerable();

        }

        public T GetModel(Func<T, bool> predicate = null)
        {
            return _DbSet.FirstOrDefault(predicate);
        }

        public T GetModelById(int ModelId)
        {
            return _DbSet.Find(ModelId);
        }

        public bool InsertModel(T model)
        {
            bool flag = true;
            try {_DbSet.Attach(model);
                _DbSet.Add(model); }
            catch { flag = false; };

            return flag;
        }

        public bool UpdateModel(T model)
        {
            bool flag = true;
            try
            {// _DbSet.Attach(model);
                _DbSet.AddOrUpdate(model);

            }
            catch { flag = false; };

            return flag;
        }

    }
}