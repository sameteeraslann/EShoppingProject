using EShoppingProject.Domain.Repositories.EntityTypeRepo;
using EShoppingProject.Domain.UnitOfWork;
using EShoppingProject.Infrastructure.Context;
using EShoppingProject.Infrastructure.Repositories.EntityTypeRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingProject.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork // =>IUnitOfWork implement yolu ile gövdelendireceğim methodlarımı aldım.
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            this._db = db ?? throw new ArgumentNullException("Database Boş Olamaz..!"); // => ?? Karar mekanizmasını başlattık.Bu karar mekanizması ya bize db bağlantısını dönecek ya da ArgumentNullException ile hata mesajı verecek.
        }


        private IAppUserRepository _appUserRepository;
        public IAppUserRepository AppUserRepository
        {
            get
            {
                if (_appUserRepository == null) _appUserRepository = new AppUserRepository(_db); // =>_appUserRepository boş gelirse databse bağlantısını üret.
                return _appUserRepository; // => daha sonrada bu db bağlantısını bana döndür.
            }
        }
       
     

        private IProductRepository _productRepository;
        public IProductRepository ProductRepository 
        {
            get
            {
                if (_productRepository == null) _productRepository = new ProductRepository(_db);
                return _productRepository;
            }
        }

        private ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository 
        {

            get
            {
                if (_categoryRepository == null) _categoryRepository = new CategoryRepository(_db);
                return _categoryRepository;
            }
        }

        private ISubCategoryRepository _subRepository;
        public ISubCategoryRepository SubCategoryRepository
        {
            get
            {
                if (_subRepository == null) _subRepository = new SubCategoryRepository(_db);
                return _subRepository;

            }
        }

        public async Task Commit() => await _db.SaveChangesAsync();

        private bool isDisposing = false;
        public async ValueTask DisposeAsync()
        {
            if (!isDisposing)
            {
                isDisposing = true;
                await DisposeAsync(true);
                GC.SuppressFinalize(this); // => Nesnemizi tamamıyla temizlenmesini sağlayacak.
            }
        }
        private async Task DisposeAsync(bool disposing)
        {
            if (disposing) await _db.DisposeAsync(); // => Üretilen db nesnemizi dispose ettik.
        }

        public Task ExecuteSqlRaw(string sql, params object[] parameters)// => Bu method içerisine sql sorgusu alacak execute edececek ve paramters gönderecek
        {
            throw new NotImplementedException();
        }
    }
}
