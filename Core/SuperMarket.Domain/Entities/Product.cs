using SuperMarket.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Domain.Entities
{
    public class Product : BaseEntity
    {
        public  int CategoryId {  get; set; }
        public Category Category { get; set; }
        public IList<OrderDetails> OrderDetails { get; set; }
        public string Name {  get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }
    }
}
