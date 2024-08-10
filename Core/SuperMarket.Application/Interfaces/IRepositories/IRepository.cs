using Microsoft.EntityFrameworkCore;
using SuperMarket.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Interfaces.IRepositories
{
   public interface IRepository<T> where T : BaseEntity
    {        
        DbSet<T> Table { get; }
        IQueryable<T> GetAll();
        Task<T> GetByIDAsync(int id);
        Task<bool> AddAsync(T data);
        bool Remove(T data);
        Task<bool> RemoveByID(int id);
        bool Update(T data);
    }
}
