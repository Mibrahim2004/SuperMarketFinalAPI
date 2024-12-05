﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.DTOs.CustomerDTOs
{
    public class CustomerCreateDTO
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public string Address { get; set; }
        public string UserId {  get; set; }
    }
}