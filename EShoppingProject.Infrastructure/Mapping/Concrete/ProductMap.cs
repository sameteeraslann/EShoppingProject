using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Infrastructure.Mapping.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Infrastructure.Mapping.Concrete
{
    public class ProductMap: BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductName).IsRequired(true); // Product Name girilmesi zorunlu kıldık.
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.UnitPrice).IsRequired(true);
            builder.Property(x => x.ImagePath).IsRequired(false);

            


            builder.HasMany(x => x.AssignedAppUserToProducts)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
