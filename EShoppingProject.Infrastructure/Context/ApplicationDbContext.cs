using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Infrastructure.Mapping.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShoppingProject.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppRole,int> // => AppUser Identity'den besleneceği için ekstra bir daha DbSet yapmaya gerek yok.
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } // Asp.Net.Core Db bağlantısı için oluşturulmuştur.

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<AssignedAppUserToProduct> AssignedAppUserToProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder) // => Mapping olarak oluşturduğumuz kuralları burada override ederek Db'ye gönderiyoruz.
        {

            builder.Entity<Product>().Property(x => x.UnitPrice).HasColumnType("decimal");


            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new AppRoleMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new SubCategoryMap());
            builder.ApplyConfiguration(new AssignedAppUserToProductMap());

            base.OnModelCreating(builder);
        }

        // Uygulamada lazy loading açmak için kullanılır.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
