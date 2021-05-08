using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Infrastructure.Mapping.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Infrastructure.Mapping.Concrete
{
    public class SubCategoryMap: BaseMap<SubCategory>
    {
        public override void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired(true);

            builder.HasOne(x=> x.Category)
                .WithMany(x=> x.SubCategories)
                .HasForeignKey(x=> x.CategoryId).OnDelete(DeleteBehavior.Restrict);
            base.Configure(builder);
        }
    }
}
