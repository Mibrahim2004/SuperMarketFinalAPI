using SuperMarket.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public int ProductId {  get; set; }
        public int BranchId {  get; set; }
        public int Quantity {  get; set; }
    }
}
