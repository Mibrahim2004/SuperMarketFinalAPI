using SuperMarket.Application.Interfaces.IRepositories.IOrderRepos;
using SuperMarket.Application.Interfaces.IRepositories.IProductRepos;
using SuperMarket.Domain.Entities;
using SuperMarket.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Implementations.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
                
        }
    }
}
