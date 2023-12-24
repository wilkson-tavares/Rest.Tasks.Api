using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Tasks.Domain.Interfaces.Generics;
using Tasks.Infra.Configuration;

namespace Tasks.Infra.Repository.Generics
{
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _dbOptions;
        public RepositoryGeneric()
        {
            _dbOptions = new DbContextOptions<ContextBase>();
        }
        
        public async Task Add(T obj)
        {
            using (var data = new ContextBase(_dbOptions))
            {
                await data.Set<T>().AddAsync(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T obj)
        {
             using (var data = new ContextBase(_dbOptions))
            {
                data.Set<T>().Remove(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetById(Guid id)
        {
            using (var data = new ContextBase(_dbOptions))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> List(T obj)
        {
            using (var data = new ContextBase(_dbOptions))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T obj)
        {
             using (var data = new ContextBase(_dbOptions))
            {
                data.Set<T>().Update(obj);
                await data.SaveChangesAsync();
            }
        }
        


        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}