using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Configurations.EntityConfig
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(od => od.Id);

            builder.Property(o => o.OrderId).IsRequired();
            builder.Property(o => o.ProductId).IsRequired();
            builder.Property(o => o.Quantity).IsRequired();
            builder.Property(o => o.Price).IsRequired().HasColumnType("decimal(18,2)");


            builder.HasOne(od => od.Order)
                   .WithMany(o => o.OrderDetails)
                   .HasForeignKey(od => od.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(od => od.Product)
                  .WithMany(p => p.OrderDetails)
                  .HasForeignKey(od => od.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}