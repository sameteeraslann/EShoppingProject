using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Domain.Repositories.EntityTypeRepo;
using EShoppingProject.Infrastructure.Context;
using EShoppingProject.Infrastructure.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Infrastructure.Repositories.EntityTypeRepo
{
    public class AppUserRepository:BaseRepository<AppUser>, IAppUserRepository// => BaseRepository<AppUser> tipinde kalıtım aldık. Daha sonra inject edeceğimiz IAppUserRepository tanımladık. Bunu yapmamızın amacı DIP prensibine uymamız. Sınıfları olabildiğince birbirinden bağımsız hale getirmek.
    {
        public AppUserRepository(ApplicationDbContext applicationDbContext): base(applicationDbContext)  { } // => Database bağlantısı yapıldı.
    }
}
