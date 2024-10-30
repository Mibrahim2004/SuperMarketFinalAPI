using SuperMarket.Application.Interfaces.IRepositories.IInventoryRepos;
using SuperMarket.Domain.Entities;
using SuperMarket.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Implementations.Repositories
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}