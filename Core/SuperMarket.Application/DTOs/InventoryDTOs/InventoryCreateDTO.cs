﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.DTOs.InventoryDTOs
{
    public class InventoryCreateDTO
    {
        public int ProductId { get; set; }
        public int BranchId { get; set; }
        public int Quantity { get; set; }
    }
}
