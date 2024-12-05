using SuperMarket.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }    
        public IList<OrderDetails> OrderDetails { get; set; }
        public IList<Payment> Payment { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount {  get; set; }
    }
}
