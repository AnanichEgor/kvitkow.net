using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Logging.Data.DbModels.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Logging.Data.Infrastructure
{
    public interface IRepository<TEntity, in TKey> : IDisposable where TEntity : Entity<TKey>
    {
        DbSet<TEntity> DbSet { get; }

        Task<TEntity> GetByIdAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] include);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] include);

        void Create(TEntity instance);

        void Update(TEntity instance);

        void Delete(TEntity instance);

        Task DeleteAsync(TKey id);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);

        Task SaveAsync();
    }
}
