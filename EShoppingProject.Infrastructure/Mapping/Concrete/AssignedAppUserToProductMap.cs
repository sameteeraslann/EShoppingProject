using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Infrastructure.Mapping.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Infrastructure.Mapping.Concrete
{
    public class AssignedAppUserToProductMap : BaseMap<AssignedAppUserToProduct>
    {
        public override void Configure(EntityTypeBuilder<AssignedAppUserToProduct> builder)
        {
            builder.HasKey(x => new { x.AppUserId, x.ProductId });

            builder.HasOne(x => x.Product)
                 .WithMany(x => x.AssignedAppUserToProducts)
                 .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.AppUser)
                 .WithMany(x => x.AssignedAppUserToProducts)
                 .HasForeignKey(x => x.AppUserId);
        }
    }
}
