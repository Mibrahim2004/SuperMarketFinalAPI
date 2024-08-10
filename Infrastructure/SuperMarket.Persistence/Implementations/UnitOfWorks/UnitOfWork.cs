using SuperMarket.Application.Interfaces.IRepositories;
using SuperMarket.Application.Interfaces.IUnitOfWorks;
using SuperMarket.Domain.Entities.Common;
using SuperMarket.Persistence.Contexts;
using SuperMarket.Persistence.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Implementations.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext DbContext;
        private Dictionary<Type, object> _repositories;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            _repositories = new();
        }
        public void Dispose()
        {
            DbContext.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }
            IRepository<TEntity> repository = new Repository<TEntity>(DbContext);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}
