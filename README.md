Asp.NetCore versiyon 7.0
<br/>
Onion Architecture(Core–Infrastructure –Presentation )
<br/>
Redis Eklendi.<br/>
Not : AutoMapper sonradan Ekledim
<br/>
Exception handling (global veya try-catch ile)<br/>
Global Hata Yönetimi eklendi<br/>


PostgreSql Veri Tabanı Kullanıldı<br/>
veritabanı Bağlantı Demo.Api/appsettings.Development.json Dosyası içerisinde DefaultConnection
<br/>
dotnet EF Core ile<br/>
<br/>
Migration Oluşturulması : <br/>
<br/>
dotnet ef migrations add initNew --project ./Infrastructure/Demo.Persistence --startup-project ./Presentation/Demo.Api
<br/>
Veri Tabanının Yüklenmesi : <br/>
dotnet ef database update --project ./Infrastructure/Demo.Persistence --startup-project ./Presentation/Demo.Api
<br/>
<br/>
dotnet build<br/>
dotnet run --project ./Presentation/Demo.Api<br/>
<br/>
localhost/swagger<br/>