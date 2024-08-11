using SuperMarket.Application.Interfaces.IRepositories.IOrderDetailsRepos;
using SuperMarket.Application.Interfaces.IRepositories.IOrderRepos;
using SuperMarket.Domain.Entities;
using SuperMarket.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Implementations.Repositories
{
    public  class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
                
        }
    }
}
