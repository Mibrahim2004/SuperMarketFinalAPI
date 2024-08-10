﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Domain.Entities;
using SuperMarket.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Contexts
{
   public class ApplicationDbContext  : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> _OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> _Payment { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
