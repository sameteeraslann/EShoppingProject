using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Domain.Repositories.EntityTypeRepo;
using EShoppingProject.Infrastructure.Context;
using EShoppingProject.Infrastructure.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Infrastructure.Repositories.EntityTypeRepo
{
    public class ProductRepository:BaseRepository<Product>,IProductRepository
    {
        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { }
    }
}
