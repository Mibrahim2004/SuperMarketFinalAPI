using SuperMarket.Application.Interfaces.IRepositories;
using SuperMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Interfaces.IPaymentRepos
{
    public interface IPaymentRepository : IRepository<Payment>
    {

    }
}
