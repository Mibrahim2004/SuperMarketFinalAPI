using SuperMarket.Application.Interfaces.IRepositories.ICategoryRepos;
using SuperMarket.Domain.Entities;
using SuperMarket.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Implementations.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
