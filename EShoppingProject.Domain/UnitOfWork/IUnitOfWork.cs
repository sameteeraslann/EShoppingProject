using EShoppingProject.Domain.Repositories.EntityTypeRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingProject.Domain.UnitOfWork
{
    public interface IUnitOfWork: IAsyncDisposable
    {
        IAppUserRepository AppUserRepository { get; }
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }


        Task Commit(); //Başarılı bir işlemin sonucunda çalıştırılır. İşlemin başlamasından itibaren tüm değişikliklerin veri tabanına uygulanmasını temin eder.

        Task ExecuteSqlRaw(string sql, params object[] parameters); // Mevcut sql sorgularımızı doğrudan veri tabanında yürütmek için kullanılan bir method.
    }
}
