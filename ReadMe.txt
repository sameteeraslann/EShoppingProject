
1. EShoppingProject ad�nda Blank Solution a��l�r.

 Not : DDD Katmanl� mimari ile ilgili daha fazla bilgi almak i�in bknz https://samettteraslan.gitbook.io/ddd-katmanli-mimari/

2. EShoppingProject.Domain ad�nda ClassLibrary(.Core) Projesi a��l�r.

Domain : Fonksiyonelite a��s�ndan zengin domain in kolay anla��labilir bir modelidir.Repositoryler ve factory ler bu katman�n birer �yeleri olarak kabul edilseler de co�u ORM ara�lar� taraf�ndan altyap� katman�na ait �yeler olarak kabul g�rmektedirler.


	2.1 Enums klas�r� a��l�r ve bu kkas�r alt�na Status.cs a��l�r.

	2.2 Entities klas�r� a��l�r. Interface ve Concrete klas�rleri alt�nda projede ihtiya� duyulan varl�klar yarat�l�r. 
	
		2.2.1 Interface klas�r�n�n alt�na IBaseEntity.cs a��l�r.

		2.2.2 Concrete bu klas�r�de projemizde ihtiya� duyulan s�n�flar olu�turulur. 
			2.2.2.1 BaseEntity.cs a��l�r child s�n�flara kal�t�m vermek ama�l� a��l�r ve abstract olarak i�aretlenir, IBaseEntity'den implement al�n�r ve IBaseEntity'de yazd���m�z propertyler burada g�vde kazan�r.


		Not: Microsoft.EntityFrameworkCore y�klenir.(5.0.2) Nuget Package Manager'den y�klenir.

		Not: Kullan�c� ile ilgili i�lemlerde Microsoft.Extensions.Identity.Stores s�n�f�ndan yararlanaca��m. Bu ba�lamda AppUserRole ve AppUser s�n�flar�nda Identity s�n�fdan kal�t�m alacaklar. Bunu i�in Microsoft.AspCore.Identity(5.0.2) paketini y�kleyece�iz.

			2.2.2.2 AppUser.cs a��l�r IdentityUser'dan kal�t�m al�r.
			2.2.2.3 AppRole.cs a��l�r. IdentityRole'den kal�t�m al�r.
			2.2.2.4
			2.2.2.5


	2.3 Repositories klas�r� a��l�r. Projede temel anlamda CRUD operasyonlar�n� y�r�tece�im methodlar� asenkron programing'e uygun �ekilde olu�turaca��m.

	Not: GenericRepository ile ilgili daha fazla bilgi i�in bknz https://samettteraslan.gitbook.io/desing-patterns/

		2.3.1 BaseRepo klas�r� a��l�r.
			2.3.1.1 IBaseRepository.cs a��l�r burada AppUser i�lemlerinde kullan�cak CRUD methodlar ve filtre i�lemlerinde kullan�lacak sorgular�n yaz�l�r.

		2.3.2 IAppUserRepository.cs a��l�r. Bu s�n�f IBaseRepository'den AppUser tipinde kall�t�m verece�iz.
		2.3.3
		2.3.4
		2.3.5
	
	2.4 UnitOfWork klas�r� a��l�r.

	Not: UnitOfWork ile ilgili daha fazla bilgi i�in bknz https://samettteraslan.gitbook.io/desing-patterns/

		2.4.1 IUnitOfWork.cs a��l�r. Bu aray�zde Unit Of Work desenine dahil etmek istedi�imiz Repository'leri ekliyoruz.

3. EShopping.Infrastructure ad�nda Class Library (.Core) Projesi a��l�r.

Infrastructure: Teknolojiye �zel kararlara odaklan�l�r ama�tan ziyade implementasyon k�sm� ile ilgilenilir.Bu katmanda domainlerin instancelar� yarat�labilir.Ancan genellikle repositoryler bu katmanda etkile�im i�erisinde olurlar.

	Not: EShoppingProject.Domain katman�ndan referans al�nmas� gerekiyor. 
	Not: Microsoft.EntityFrameworkCore y�klenir.(5.0.2) Nuget Package Manager'den y�klenir.
	

	3.1 Mapping klas�r� a��l�r. Bu klas�r alt�nda Mapleme i�lemleri uygulan�r.
		3.1.1 Abstract klas�r� a��l�r. Alt�na child map katman�nda ortak olan �zellikleri buraya tan�ml�yoruz.
			3.1.1.1 BaseMap.cs a��l�r.

		3.1.2 Concrete klas�r� a��l�r. Bu klas�rde Entitylerin kendilerine �zel Mapleme i�lemleri yap�l�r.
			3.1.2.1 AppUserMap.cs BaseMap den kal�t�m al�r.
			3.1.2.2 AppRoleMap.cs BaseMap den kal�t�m al�r.
			3.1.2.3
			3.1.2.4
			3.1.2.5

	3.2 Context klas�r� a��l�r.
		3.3.1 ApplicationDbContext.cs a��l�r. CodeFirst ile aya�a kald�raca��m�z projen�n tablolar�n� DbSet edece�iz ve Mapping i�erisinde yapm�� oldu�umuz Map'leme i�lemlerini override edece�iz.

		Not: Microsoft.AspNetCore.Identity.EntityFrameworkCore(5.0.2) Nuget Package Manager'den y�klenir.
		Not: Microsoft.EntityFrameworkCore.SqlServer(5.0.2) Nuget Package Manager'den y�klenir.
		Not: Microsoft.EntityFrameworkCore.Tools (5.0.2) Nuget Package Manager'den y�klenir.
	
	3.3 Repositories Klas�r� a��l�r. Burada Domain k�sm�nda olu�turdu�umuz Generic Repository'lere g�vde kazand�raca��z.
	
		
		3.3.1 AppUserRepository a��l�r.
		3.3.2
		3.3.3
		3.3.4


	3.4 UnitOfWork Klas�r� a��l�r.
		3.4.1 UnitOfWork.cs eklenir. Burada TwitterProject.Domain katman�nda olu�turdu�umuz UnitOfWork methodlar�n� g�vdelendirece�iz.

4. EShopping.Application ad�nda Class Library (.Core) Projesi a��l�r.

	Not: EShoppingProject.Domain,
			EShopping.Infrastructure katmanlar�ndan referans al�n�r.  

	Not: Microsoft.AspNetCore.Identity (2.2.0) Nuget Package Manager'den y�klenir.

		4.1 Services klas�r� a��l�r.
			4.1.1 Interfaces klas�r� a��l�r
				4.1.1.1 IAppUserServices.cs a��l�r.
				4.1.1.2
				4.1.1.3
				4.1.1.4

			4.1.2 Concrete klas�r� a��l�r.
				4.1.2.1 AppUserServices.cs a��l�r.
				4.1.2.2
				4.1.2.3
				4.1.2.4
		
		4.2 Model klas�r� a��l�r. Burada projede ihtiya�lar�m�za y�nelik DTO ve VM ile ilgili i�lemleri yap�yoruz.

			DTO ve VM ile ilgili daha fazla bilgi almak isterseniz bknz https://samettteraslan.gitbook.io/object-operations/

			4.2.1 DTOs klas�r� a��l�r.
				4.2.1.1 EditProfileDTO a��l�r.
				4.2.1.2 LoginDTO a��l�r.
				4.2.1.3 ProfileDTO a��l�r
				4.2.1.4 RegisterDTO a��l�r.

			4.2.2 VMs klas�r� a��l�r.
				4.2.2.1
				4.2.2.2
				4.2.2.3
				4.2.2.4

		4.3 Mapper klas�r� a��l�r. Burada AutoMapper yapaca��m�z Map leri Create edece�iz.
			Not: AutoMapper ile ilgili bilgi almak isterseniz bknz. https://samettteraslan.gitbook.io/object-operations/

			Not: AutoMapper (10.1.1) Nuget Package Manager'den y�klenir.
			Not: AutoMapper.Extensions.Microsoft.DependendencyInjection(8.1.0) Nuget Package Manager'den y�klenir.

			4.3.1 Mapper klas�r� a��l�r.
				4.3.1.1 Mapping.cs a��l�r. Burada conscructor method i�erisinde Mapping i�lemlerimizi yapaca��z.


		4.4 IoC klas�r� a��l�r. Ben burada AUTOFAC Container kullanaca��m. Genel olarak Containerler'� kullanma amac�m�z ba��ml�l�klar� tersine �evirmeyi temiz ediyor. Bu y�ntem new yapman�n s�k� s�k�ya ba�l�l���n� ortadan kald�r�r.

				------------------------BURAYA G�TBOOK L�NK EKLE------------

			Not: Autofac(6.1.0) Nuget Package Manager'den y�klenir.
				4.4.1	AutoFacContainer.cs a��l�r.

		4.5 Extensions klas�r� a��l�r.
			4.5.1 ClaimsPrincipalExtensions.cs a��l�r. Kullan�c�dan al�nan bilgilerin belirli �artlara uymas� sa�lan�r.
	
		4.6 Validations klas�r� a��l�r. Burada Validate(ModelState) i�lemleri uygulan�r.
			
			Not: FluentValidation.AspNetCore(9.5.1) Nuget Package Manager'den y�klenir.

			4.6.1 LoginValidation

	5.EShopping.Presentation (ASP.NET Core Web Application) a��l�r.




	
	


	



	ImageResizer 4 2 8
	ImageResizer.Plugins.DiskCache 428




	u� katman� 


	Microsoft.EntityFrameworkCore 502
	Microsoft.EntityFrameworkCore.Design 502
	Microsoft.EntityFrameworkCore.SqlServer 502

	Autofac.Extensions.DependencyInjection 710