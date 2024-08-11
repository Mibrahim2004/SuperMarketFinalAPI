﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.DTOs.OrderDTOs
{
   public class OrderCreateDTO
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
    }
}