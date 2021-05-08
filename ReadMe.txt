
1. EShoppingProject adýnda Blank Solution açýlýr.

 Not : DDD Katmanlý mimari ile ilgili daha fazla bilgi almak için bknz https://samettteraslan.gitbook.io/ddd-katmanli-mimari/

2. EShoppingProject.Domain adýnda ClassLibrary(.Core) Projesi açýlýr.

Domain : Fonksiyonelite açýsýndan zengin domain in kolay anlaþýlabilir bir modelidir.Repositoryler ve factory ler bu katmanýn birer üyeleri olarak kabul edilseler de coðu ORM araçlarý tarafýndan altyapý katmanýna ait üyeler olarak kabul görmektedirler.


	2.1 Enums klasörü açýlýr ve bu kkasör altýna Status.cs açýlýr.

	2.2 Entities klasörü açýlýr. Interface ve Concrete klasörleri altýnda projede ihtiyaç duyulan varlýklar yaratýlýr. 
	
		2.2.1 Interface klasörünün altýna IBaseEntity.cs açýlýr.

		2.2.2 Concrete bu klasörüde projemizde ihtiyaç duyulan sýnýflar oluþturulur. 
			2.2.2.1 BaseEntity.cs açýlýr child sýnýflara kalýtým vermek amaçlý açýlýr ve abstract olarak iþaretlenir, IBaseEntity'den implement alýnýr ve IBaseEntity'de yazdýðýmýz propertyler burada gövde kazanýr.


		Not: Microsoft.EntityFrameworkCore yüklenir.(5.0.2) Nuget Package Manager'den yüklenir.

		Not: Kullanýcý ile ilgili iþlemlerde Microsoft.Extensions.Identity.Stores sýnýfýndan yararlanacaðým. Bu baðlamda AppUserRole ve AppUser sýnýflarýnda Identity sýnýfdan kalýtým alacaklar. Bunu için Microsoft.AspCore.Identity(5.0.2) paketini yükleyeceðiz.

			2.2.2.2 AppUser.cs açýlýr IdentityUser'dan kalýtým alýr.
			2.2.2.3 AppRole.cs açýlýr. IdentityRole'den kalýtým alýr.
			2.2.2.4
			2.2.2.5


	2.3 Repositories klasörü açýlýr. Projede temel anlamda CRUD operasyonlarýný yürüteceðim methodlarý asenkron programing'e uygun þekilde oluþturacaðým.

	Not: GenericRepository ile ilgili daha fazla bilgi için bknz https://samettteraslan.gitbook.io/desing-patterns/

		2.3.1 BaseRepo klasörü açýlýr.
			2.3.1.1 IBaseRepository.cs açýlýr burada AppUser iþlemlerinde kullanýcak CRUD methodlar ve filtre iþlemlerinde kullanýlacak sorgularýn yazýlýr.

		2.3.2 IAppUserRepository.cs açýlýr. Bu sýnýf IBaseRepository'den AppUser tipinde kallýtým vereceðiz.
		2.3.3
		2.3.4
		2.3.5
	
	2.4 UnitOfWork klasörü açýlýr.

	Not: UnitOfWork ile ilgili daha fazla bilgi için bknz https://samettteraslan.gitbook.io/desing-patterns/

		2.4.1 IUnitOfWork.cs açýlýr. Bu arayüzde Unit Of Work desenine dahil etmek istediðimiz Repository'leri ekliyoruz.

3. EShopping.Infrastructure adýnda Class Library (.Core) Projesi açýlýr.

Infrastructure: Teknolojiye özel kararlara odaklanýlýr amaçtan ziyade implementasyon kýsmý ile ilgilenilir.Bu katmanda domainlerin instancelarý yaratýlabilir.Ancan genellikle repositoryler bu katmanda etkileþim içerisinde olurlar.

	Not: EShoppingProject.Domain katmanýndan referans alýnmasý gerekiyor. 
	Not: Microsoft.EntityFrameworkCore yüklenir.(5.0.2) Nuget Package Manager'den yüklenir.
	

	3.1 Mapping klasörü açýlýr. Bu klasör altýnda Mapleme iþlemleri uygulanýr.
		3.1.1 Abstract klasörü açýlýr. Altýna child map katmanýnda ortak olan özellikleri buraya tanýmlýyoruz.
			3.1.1.1 BaseMap.cs açýlýr.

		3.1.2 Concrete klasörü açýlýr. Bu klasörde Entitylerin kendilerine özel Mapleme iþlemleri yapýlýr.
			3.1.2.1 AppUserMap.cs BaseMap den kalýtým alýr.
			3.1.2.2 AppRoleMap.cs BaseMap den kalýtým alýr.
			3.1.2.3
			3.1.2.4
			3.1.2.5

	3.2 Context klasörü açýlýr.
		3.3.1 ApplicationDbContext.cs açýlýr. CodeFirst ile ayaða kaldýracaðýmýz projenýn tablolarýný DbSet edeceðiz ve Mapping içerisinde yapmýþ olduðumuz Map'leme iþlemlerini override edeceðiz.

		Not: Microsoft.AspNetCore.Identity.EntityFrameworkCore(5.0.2) Nuget Package Manager'den yüklenir.
		Not: Microsoft.EntityFrameworkCore.SqlServer(5.0.2) Nuget Package Manager'den yüklenir.
		Not: Microsoft.EntityFrameworkCore.Tools (5.0.2) Nuget Package Manager'den yüklenir.
	
	3.3 Repositories Klasörü açýlýr. Burada Domain kýsmýnda oluþturduðumuz Generic Repository'lere gövde kazandýracaðýz.
	
		
		3.3.1 AppUserRepository açýlýr.
		3.3.2
		3.3.3
		3.3.4


	3.4 UnitOfWork Klasörü açýlýr.
		3.4.1 UnitOfWork.cs eklenir. Burada TwitterProject.Domain katmanýnda oluþturduðumuz UnitOfWork methodlarýný gövdelendireceðiz.

4. EShopping.Application adýnda Class Library (.Core) Projesi açýlýr.

	Not: EShoppingProject.Domain,
			EShopping.Infrastructure katmanlarýndan referans alýnýr.  

	Not: Microsoft.AspNetCore.Identity (2.2.0) Nuget Package Manager'den yüklenir.

		4.1 Services klasörü açýlýr.
			4.1.1 Interfaces klasörü açýlýr
				4.1.1.1 IAppUserServices.cs açýlýr.
				4.1.1.2
				4.1.1.3
				4.1.1.4

			4.1.2 Concrete klasörü açýlýr.
				4.1.2.1 AppUserServices.cs açýlýr.
				4.1.2.2
				4.1.2.3
				4.1.2.4
		
		4.2 Model klasörü açýlýr. Burada projede ihtiyaçlarýmýza yönelik DTO ve VM ile ilgili iþlemleri yapýyoruz.

			DTO ve VM ile ilgili daha fazla bilgi almak isterseniz bknz https://samettteraslan.gitbook.io/object-operations/

			4.2.1 DTOs klasörü açýlýr.
				4.2.1.1 EditProfileDTO açýlýr.
				4.2.1.2 LoginDTO açýlýr.
				4.2.1.3 ProfileDTO açýlýr
				4.2.1.4 RegisterDTO açýlýr.

			4.2.2 VMs klasörü açýlýr.
				4.2.2.1
				4.2.2.2
				4.2.2.3
				4.2.2.4

		4.3 Mapper klasörü açýlýr. Burada AutoMapper yapacaðýmýz Map leri Create edeceðiz.
			Not: AutoMapper ile ilgili bilgi almak isterseniz bknz. https://samettteraslan.gitbook.io/object-operations/

			Not: AutoMapper (10.1.1) Nuget Package Manager'den yüklenir.
			Not: AutoMapper.Extensions.Microsoft.DependendencyInjection(8.1.0) Nuget Package Manager'den yüklenir.

			4.3.1 Mapper klasörü açýlýr.
				4.3.1.1 Mapping.cs açýlýr. Burada conscructor method içerisinde Mapping iþlemlerimizi yapacaðýz.


		4.4 IoC klasörü açýlýr. Ben burada AUTOFAC Container kullanacaðým. Genel olarak Containerler'ý kullanma amacýmýz baðýmlýlýklarý tersine çevirmeyi temiz ediyor. Bu yöntem new yapmanýn sýký sýkýya baðlýlýðýný ortadan kaldýrýr.

				------------------------BURAYA GÝTBOOK LÝNK EKLE------------

			Not: Autofac(6.1.0) Nuget Package Manager'den yüklenir.
				4.4.1	AutoFacContainer.cs açýlýr.

		4.5 Extensions klasörü açýlýr.
			4.5.1 ClaimsPrincipalExtensions.cs açýlýr. Kullanýcýdan alýnan bilgilerin belirli þartlara uymasý saðlanýr.
	
		4.6 Validations klasörü açýlýr. Burada Validate(ModelState) iþlemleri uygulanýr.
			
			Not: FluentValidation.AspNetCore(9.5.1) Nuget Package Manager'den yüklenir.

			4.6.1 LoginValidation

	5.EShopping.Presentation (ASP.NET Core Web Application) açýlýr.




	
	


	



	ImageResizer 4 2 8
	ImageResizer.Plugins.DiskCache 428




	uý katmaný 


	Microsoft.EntityFrameworkCore 502
	Microsoft.EntityFrameworkCore.Design 502
	Microsoft.EntityFrameworkCore.SqlServer 502

	Autofac.Extensions.DependencyInjection 710