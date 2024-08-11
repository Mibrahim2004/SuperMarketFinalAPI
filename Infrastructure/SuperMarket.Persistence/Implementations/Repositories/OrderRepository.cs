using SuperMarket.Application.Interfaces.IRepositories.ICustomerRepos;
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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
                
        }
    }
}
