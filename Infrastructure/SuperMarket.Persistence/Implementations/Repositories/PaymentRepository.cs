using SuperMarket.Application.Interfaces.IRepositories.IPaymentRepos;
using SuperMarket.Domain.Entities;
using SuperMarket.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Implementations.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            
        }
    }
}
