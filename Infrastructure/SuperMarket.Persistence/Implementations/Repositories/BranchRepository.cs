using SuperMarket.Application.Interfaces.IRepositories.IBranchRepos;
using SuperMarket.Domain.Entities;
using SuperMarket.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Implementations.Repositories
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}