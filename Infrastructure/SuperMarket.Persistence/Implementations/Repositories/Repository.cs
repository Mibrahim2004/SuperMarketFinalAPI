using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Persistence.Contexts;
using SuperMarket.Application.Interfaces.IRepositories;

namespace SuperMarket.Persistence.Implementations.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T data)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(data);
            return entityEntry.State == EntityState.Added;
        }

        public IQueryable<T> GetAll()
        {
            return Table.AsQueryable();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await Table.AsQueryable().FirstOrDefaultAsync(data => data.Id == id);

        }

        public bool Remove(T data)
        {
            EntityEntry<T> entityEntry = Table.Remove(data);

            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveByID(int id)
        {
            T entity = await Table.FindAsync(id);
            if (entity == null)
                return false; 
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Update(T data)
        {
            EntityEntry<T> entityEntry = Table.Update(data);
            return entityEntry.State == EntityState.Modified;
        }
    }
}