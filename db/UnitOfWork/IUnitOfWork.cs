using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gta5Platinum.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gta5Platinum.DataAccess.UnitOfWork
{
    public interface IUnitOfWork<out TContext> : IDisposable
       where TContext : DbContext
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        void LoadCollection<TEntity>(TEntity entity, string navigationProperty)
            where TEntity : class;

        void LoadCollection<TEntity, TElement>(TEntity entity, Expression<Func<TEntity, IEnumerable<TElement>>> navigationProperty)
            where TElement : class
            where TEntity : class;

        void LoadReference<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> navigationProperty)
            where TProperty : class
            where TEntity : class;

        void LoadReference<TEntity, TProperty>(TEntity entity, string navigationProperty)
            where TProperty : class
            where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
