using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Domain.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Domain.Repositories.EntityTypeRepo
{
    public interface ISubCategoryRepository: IBaseRepository<SubCategory>  { }
}
