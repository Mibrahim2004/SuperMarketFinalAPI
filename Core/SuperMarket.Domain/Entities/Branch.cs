﻿using SuperMarket.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Domain.Entities
{
    public class Branch : BaseEntity
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public IList<Inventory> Inventory {  get; set; }
    }
}
