﻿using SuperMarket.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Domain.Entities
{
    public class OrderDetails : BaseEntity
    {
        public int OrderId { get; set; }
        public int Quantity {  get; set; }
        public decimal Price { get; set; }
    }
}
