using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Infrastructure.Mapping.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Infrastructure.Mapping.Concrete
{
    public class CategoryMap: BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CategoryName).IsRequired(true);

            

            builder.HasMany(x => x.SubCategories)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);



            base.Configure(builder);
        }
       
    }
}
