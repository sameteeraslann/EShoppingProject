using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Infrastructure.Mapping.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Infrastructure.Mapping.Concrete
{
    public class AppRoleMap : BaseMap<AppRole>
    {
        public override void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(x => x.Id);
            base.Configure(builder);
        }
    }
}
