# Asp.Net Core 6 MVC CodeFirst - Blog Sitesi MyBlog Projesi
M&Y Yazılım Akademi Danışmanlıktan aldığım eğitim kapsamında geliştirmiş olduğum 3. proje olan blog sitesi projesidir. Proje bir blog sitesinde bütün ihtiyaçlara cevap verecek şekilde oluşturulmuştur. Okurların okumalarını yapabilecekleri, yazarları, kategorilere göre yazıları görüntüleyebilecekleri ve diğer özelliklere sahip kullanıcı paneli, mesajlaşma sistemine ve blog oluşturma yazara ait blogları düzenleme özelliklerine sahip yazarlar paneli, ve bütün bunları yönetebilen, Editörler ve Adminlerin kullanabildiği bir admin paneliyle birlikte 3 adet paneli mevcuttur.
## Projeye Ait Bazı Özellikler;
* Proje Asp.Net 6.0 MVC mimarisinde CodeFirst yaklaşımıyla yapıldı.
* Projede bol bol iç içe layout ve ViewComponent yapısı kullanıldı.
* Blog sayfasında okuma süreleri ve yorumları görüntülenebilmektedir. 
* Okur yazıları kategorilerine göre göre listeyebilmektedir.
* Yazarlar, editörler ve adminler birbirleriyle gelişmiş bir mesajlaşma sistemiyle mesajlaşabilmektedirler. Mesajlaşma sisteminde çöp kutusu, önemli mesajlar, taslaklar, gelen kutusu, gönderilen kutusuyla mesajlar detaylı şekilde yönetilebilmektedir.
* Okur yazarları görüntüleyebilmekte ve isterse o yazara ait blogları görüntüleyebilmektedir.
* Blog sayfasında editörün seçtiği yazılar sağ panelde görüntülenebilmektedir, okurlar yazılara yorum atabilmektedirler. İletişim sayfasından sistem yöneticilerine mesajı gönderebilmektedirler.
#### Yazarlar Paneli
* Üst barda yöneticilerden gönderilen bildirimler gösterilmektedir ve bildirim sayısı yazmaktadır. 
* Dashboard ekranında kategoriye ait blogların sayısını gösteren grafik ve hava durumu tahmini API üzerinden alınarak görüntülenebilmektedir.
* Üst barda ilgili yazara ait gelen, okunmamış mesajlar görüntülenmekte ve sayısı gösterilmektedir.
* Yazar yeni blog oluşturabilmekte, var olan kendi bloglarını görüntüleyip güncelleyebilmektedir.
* Yazar kendi bloglarına atılan yorumları ve yorumların durumlarını görüntüleyebilmektedir.
* Yazar sistemdeki diğer yazarlara, editörlere ve adminlere mesaj atıp mesajların yönetimini yapabilmektedir.
* Mesajları taslaklara, önemli mesajlara, silinenlere taşıyabilmektedir.
#### Admin - Editör Paneli
* Üst barda yöneticilerden gönderilen bildirimler gösterilmektedir ve bildirim sayısı yazmaktadır. 
* Dashboard ekranında kategoriye ait blogların sayısını gösteren grafik ve hava durumu tahmini API üzerinden alınarak görüntülenebilmektedir. Bununla birlikte o güne ait yazılan blog ve yorum sayısı görüntülenebilir.
* Üst barda ilgili kullanıcıya ait gelen, okunmamış mesajlar görüntülenmekte ve sayısı gösterilmektedir.
* Yazar yeni blog oluşturabilmekte, var olan kendi bloglarını görüntüleyip güncelleyebilmektedir.
* Bloglar, Yazarlar, Yöneticiler, Yorumlar, İletişim Mesajları, Kategoriler, Etiketler, Bildirimler, İstatistikler görüntülenebilmektedir.
* Authorize kullanılarak rol bazlı yetkilendirme sağlanıp ilgili bölümlerin yalnızca Adminler tarafından müdahale edip güncellenebilir olması sağlanmıştır.
* Editör yetkisi dışında bir alana girmeye çalıştığında editörü yetkisiz giriş sayfası karşılamaktadır.
* Ve daha bir sürü ek kurallar zinciriyle paneldeki admin-editör sistemi kurulmuştur.

### Kullanılan Bazı Teknolojiler
* Structural Repository design pattern ile oluşturulmuştur.
* DbCodeFirst ile MSSQL veritabanı oluşturulup yönetimi sağlandı.
* Identity kütüphanesiyle login-logout sistemi kullanıldı.
* Entity Framework 6.0 Veritabanı etkileşimi ve ORM için kullanıldı.
* Area sistemiyle paneller birbirinden ayrılıp yönetimi kolaylaştırıldı.
* ExpandViewLocations kullanılarak view konumları genişletilerek kullanıldı.
* HTML-CSS Bootstrap ile arayüzler tasarlandı.
* Rapid API - Hava durumu bilgisi çekildi.
* Fluent Validation - kontrol sistemi kullanılarak veirlerin belli kurallara göre alınması sağlandı.
* ViewBaglerle verilerin taşınması.
* GoogleChart ile dashboardda istatistiki veriler gösterildi.
* 403 - 404 sayfalarının bulunması.
* Authentication - authorize sistemi.
* AutoMapper nesneyle nesnenin eşleşmesi sağlandı.
* Login sistemi
* Linq sorguları

# Vertabanı
![Veritabanı](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/database.png?raw=true)

# Yönetici Paneli
#### Dashboard
![Dashboard](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/dashboard.png?raw=true)

# Yazar Paneli
#### Dashboard
![Dashboard](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/dashboard.png?raw=true)
#### Dashboard Bildirim
![Dashboard Bildirim](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/dashboardnotif.png?raw=true)
#### Kategoriler
![Kategoriler](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/categorylist.png?raw=true)
#### Ürünler
![Ürünler](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/productlist.png?raw=true)
#### Şefler
![Şefler](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/cheflist.png?raw=true)
#### Rezervasyonlar
![Rezervasyonlar](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/reservationlist.png?raw=true)
#### Rezervasyon Güncelleme
![Rezervasyon Güncelleme](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/reservationupdate.png?raw=true)
#### Bildirimler
![Bildirimler](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/notificationlist.png?raw=true)
#### İletişim Bilgileri
![İletişim Bilgileri](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/contactlist.png?raw=true)
#### Hakkımızda Bilgileri
![Hakkımızda Bilgileri](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/aboutlist.png?raw=true)
#### Adres Bilgileri
![Adres Bilgileri](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/addresslist.png?raw=true)
#### Çalışma Saat Bilgileri
![Çalışma Saati Bilgileri](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/workhourlist.png?raw=true)
#### Profil Güncelleme
![Profil Güncelleme](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/profileupdate.png?raw=true)

# Yönetici Paneli

### Slider
![Slider](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/slider.png?raw=true)
### Hakkımızda
![Hakkımızda](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/about.png?raw=true)
### Şefler
![Şefler](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/chef.png?raw=true)
### Menü
![Şefler](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/menu.png?raw=true)
### İletişim
![İletişim](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/contact.png?raw=true)
### Yorumlar
![Yorumlar](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/testimonial.png?raw=true)
### Rezervasyon
![Rezervasyon](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/reservation.png?raw=true)
### Footer
![Footer](https://github.com/batuhanyalin/TasteFoodIt/blob/master/TestFoodIt/ScreenShots/footer.png?raw=true)

