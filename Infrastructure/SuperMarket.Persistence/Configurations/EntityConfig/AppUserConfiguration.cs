using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Domain.Entities.Identity;

namespace SuperMarket.Persistence.Configurations.EntityConfig
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Set the primary key
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(50); 

            builder.Property(a => a.RefreshToken)
                .HasMaxLength(250); 

            builder.Property(a => a.ExpiredDate)
                .IsRequired();

            builder.Property(a => a.RefreshTokenEndTime)
              .IsRequired(); 

            // Configure the relationship with Customers
            builder.HasMany(a => a.Customer)
                .WithOne(c => c.AppUser)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}