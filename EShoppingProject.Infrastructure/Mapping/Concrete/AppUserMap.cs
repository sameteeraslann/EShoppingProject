using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Infrastructure.Mapping.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Infrastructure.Mapping.Concrete
{
    public class AppUserMap : BaseMap<AppUser>
    {

        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id); //=> AppUser ıd'yi primary key olarak belirledik.

            builder.Property(x => x.FullName).IsRequired(true).HasMaxLength(50); // => FullName boş geçilmesin ve maximum karakteri "50" olarak belirledik.
            builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(40);
            builder.Property(x => x.Email).IsRequired(true);
            builder.Property(x => x.Adress).IsRequired(false);

            builder.HasMany(x => x.AssignedAppUserToProducts)
               .WithOne(x => x.AppUser)
               .HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.Restrict);




            base.Configure(builder);
        }
    }
}
