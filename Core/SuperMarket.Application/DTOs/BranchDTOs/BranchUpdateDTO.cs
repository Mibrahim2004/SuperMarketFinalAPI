﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.DTOs.BranchDTOs
{
   public class BranchUpdateDTO
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string City {  get; set; }
        public string Email {  get; set; }
    }
}
