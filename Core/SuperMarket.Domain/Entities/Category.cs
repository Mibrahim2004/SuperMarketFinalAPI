using SuperMarket.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name {  get; set; }
        public IList<Product>? Product { get; set; }
    }
}
