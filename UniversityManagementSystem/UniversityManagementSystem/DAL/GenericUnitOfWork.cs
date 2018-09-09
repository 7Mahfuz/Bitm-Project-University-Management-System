using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class GenericUnitOfWork:IDisposable
    {
        private ApplicationDbContext context = null;

        public GenericUnitOfWork()
        {
            context = new ApplicationDbContext();
        }

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public _IGenericRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as _IGenericRepository<T>;
            }
            _IGenericRepository<T> repo = new GenericRepository<T>(context);

            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}