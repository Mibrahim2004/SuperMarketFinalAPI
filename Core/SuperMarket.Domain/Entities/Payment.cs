using SuperMarket.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int OrderId {  get; set; }
        public Order? Order { get; set; }
        public DateTime PaymentDate{ get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
    }
}
