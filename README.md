Asp.NetCore versiyon 7.0

Onion Architecture(Core–Infrastructure –Presentation )

Basit Redis Eklendi.
Not : AutoMapper sonradan Ekledim

Exception handling (global veya try-catch ile)
Global Hata Yönetimi eklendi


PostgreSql Veri Tabanı Kullanıldı
veritabanı Bağlantı Demo.Api/appsettings.Development.json Dosyası içerisinde DefaultConnection

dotnet EF Core ile

Migration Oluşturulması : 

dotnet ef migrations add initNew --project ./Infrastructure/Demo.Persistence --startup-project ./Presentation/Demo.Api

Veri Tabanının Yüklenmesi : 
dotnet ef database update --project ./Infrastructure/Demo.Persistence --startup-project ./Presentation/Demo.Api


dotnet build
dotnet run --project ./Presentation/Demo.Api

localhost/swagger