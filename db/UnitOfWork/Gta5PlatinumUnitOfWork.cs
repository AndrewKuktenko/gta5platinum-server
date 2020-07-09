using Gta5Platinum.DataAccess.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gta5Platinum.DataAccess.Repositories;

namespace Gta5Platinum.DataAccess.UnitOfWork
{
    public class Gta5PlatinumUnitOfWork : IGta5PlatinumUnitOfWork
    {
        private readonly Hashtable _repositories;

        private readonly Gta5PlatinumDbContext _context;

        public Gta5PlatinumUnitOfWork() : this(new Gta5PlatinumDbContext()) { }

        public Gta5PlatinumUnitOfWork(Gta5PlatinumDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            var entityTypeName = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(entityTypeName))
            {
                var repositoryInstance = new GenericRepository<TEntity, Gta5PlatinumDbContext>(_context);

                _repositories.Add(entityTypeName, repositoryInstance);
            }

            return (IRepository<TEntity>)_repositories[entityTypeName];
        }

        public void LoadCollection<TEntity>(TEntity entity, string navigationProperty) where TEntity : class
        {
            _context.Entry(entity).Collection(navigationProperty).Load();
        }

        public void LoadCollection<TEntity, TElement>(TEntity entity, Expression<Func<TEntity, IEnumerable<TElement>>> navigationProperty)
            where TEntity : class
            where TElement : class
        {
            _context.Entry(entity).Collection(navigationProperty).Load(); //TODO: Разобраться и исправить
        }

        public void LoadReference<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> navigationProperty)
            where TEntity : class
            where TProperty : class
        {
            _context.Entry(entity).Reference(navigationProperty).Load();
        }

        public void LoadReference<TEntity, TProperty>(TEntity entity, string navigationProperty)
            where TEntity : class
            where TProperty : class
        {
            _context.Entry(entity).Reference<TProperty>(navigationProperty).Load();
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #region Dispose Pattern
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_context != null)
                    _context.Dispose();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion Dispose Pattern
    }
}
