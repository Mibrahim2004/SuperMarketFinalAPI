using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Configurations.EntityConfig
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(i => i.Id);
        
            builder.Property(i => i.Quantity)
                .IsRequired();

            // Configuring relationships
            builder.HasOne(i => i.Branch)
                .WithMany(b => b.Inventory)
                .HasForeignKey(i => i. BranchId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}