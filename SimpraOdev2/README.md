<h3>Bu proje Patika.Dev'in düzenlemiş olduğu Simpra .Net Bootcamp'inin 2.ödevi kapsamında yapılmıştır.</h3>

Proje 4 katmandan oluşmaktadır.

<h4>EntityLayer: Bu katmanda veri tabanı tablolarının sınıfları tutulmaktadır.</h4>

--> Models: Veri tabanı tablosunun sınıfı burada bulunmaktadır.

<h4>DataAccessLayer: Bu katmanda GenericRepository, Context, Mapper, Migration gibi bölümler bulunmaktadır.</h4>

-->Abstract: Burada GenericRepository ve Staff'in interfaceleri bulunmaktadır.

-->Context: Burada Context sınıfı ve Repository sınıfı tutulmaktadır. 

-->EntityFramework: Burada GenericRepository ile bağlantılar kurulmaktadır.

-->Mapper: Burada veri tabanındaki tablonun genel özellikleri tanımlanmıştır.

<h4>BusinessLayer: Bu katmanda projedeki tabloların CRUD işlemleri ve FluentValidation işlemleri gerçekleştirilmektedir.</h4>

-->Abstract: Burada Staff'in CRUD işlemleri için interface'i oluşturulmuştur.

-->Concrete: Burada Staff'in FluentValidation kontrollleri ve CRUD işlemleri gerçekleştirilmiştir.

-->FluentValidations: Burada Staff sınıfının attribute'larının gerekli kontrolleri ve hata mesajları ayarlanmıştır.

<h4>SimraOdev2: Bu katmanda projenin genel istekleri karşılanmaktadır.</h4>

-->appsettings.json: Burada veri tabanı bağlantı yolu belirtilmiştir.

-->ServiceExtension: Burada Program.cs sınıfının uzun olmaması için extension kullanılmıştır.
