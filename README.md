# Asp.Net Core 6 MVC CodeFirst - Blog Sitesi MyBlog Projesi
M&Y Yazılım Akademi Danışmanlıktan aldığım eğitim kapsamında geliştirmiş olduğum 3. proje olan blog sitesi projesidir. Proje bir blog sitesinde bütün ihtiyaçlara cevap verecek şekilde oluşturulmuştur. Okurların okumalarını yapabilecekleri, yazarları, kategorilere göre yazıları görüntüleyebilecekleri ve diğer özelliklere sahip kullanıcı paneli, mesajlaşma sistemine ve blog oluşturma yazara ait blogları düzenleme özelliklerine sahip yazarlar paneli, ve bütün bunları yönetebilen, Editörler ve Adminlerin kullanabildiği bir admin paneliyle birlikte 3 adet paneli mevcuttur.
## Projeye Ait Bazı Özellikler;
* Proje Asp.Net 6.0 MVC mimarisinde CodeFirst yaklaşımıyla yapıldı.
* Identity kütüphanesiyle login-logout-register sistemi kullanıldı.
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

# Veritabanı
![Veritabanı](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/database.png?raw=true)

# Okur Paneli
#### Anasayfa
![Anasayfa](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/default-home.png?raw=true)
![Anasayfa](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/default-home2.png?raw=true)
#### Blog Detay Sayfası
![Blog Detay Sayfası](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/default-blog-detail.png?raw=true)
#### Yazarlar
![Yazarlar](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/default-authorlist.png?raw=true)
#### Kategoriye Göre Bloglar
![Kategoriye Göre Bloglar](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/default-bloglist-forcategory.png?raw=true)
#### Yorum Yapma
![Yorum Yapma](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/default-comment-create.png?raw=true)
#### İletişim
![İletişim](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/default-contact.png?raw=true)
#### Giriş Ekranı
![Giriş Ekranı](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/login.png?raw=true)
#### Üyelik Ekranı
![Üyelik Ekranı](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/register.png?raw=true)

# Yazar Paneli
#### Dashboard
![Dashboard](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/writer-dashboard.png?raw=true)
#### Dashboard Mesaj Bildirimi
![Dashboard Mesaj Bildirimi](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/writer-dashboard-message.png?raw=true)
#### Mesajlar Gelen Kutusu
![Mesajlar Gelen Kutusu](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/writer-messageinbox.png?raw=true)
#### Profil
![Profil](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/writer-profile.png?raw=true)
#### Yorumlar
![Profil](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/writer-comment.png?raw=true)
#### Blog Oluştur
![Profil](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/writer-blogcreate.png?raw=true)
#### Bloglar
![Profil](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/writer-bloglist.png?raw=true)
#### Blog Güncelle
![Profil](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/writer-blogupdate.png?raw=true)

# Yönetici Paneli
#### Dashboard
![Dashboard](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-dashboard.png?raw=true)
#### Dashboard Mesaj Bildirimi
![Dashboard Mesaj Bildirimi](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-dashboard-message.png?raw=true)
#### Kullanıcı Güncelleme
![Kullanıcı Güncelleme](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-user-update.png?raw=true)
#### Mesajlar
##### Bütün Mesajlar
![Bütün Mesajlar](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-message-all.png?raw=true)
##### Gelen Mesajlar
![Gelen Mesajlar](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-message-inbox.png?raw=true)
##### Taslak Mesajlar
![Taslak Mesajlar](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-message-junk.png?raw=true)
##### Silinen Mesajlar
![Silinen Mesajlar](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-message-trash.png?raw=true)
##### Mesaj Güncelleme
![Mesaj Güncelleme](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-message-update.png?raw=true)
##### Mesaj Detay Sayfası
![Mesaj Detay Sayfası](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-message-detail.png?raw=true)
#### Yöneticiler
![Yöneticiler](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-adminlist.png?raw=true)
#### İstatistikler
![İstatistikler](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-statistic.png?raw=true)
#### İletişim Mesajları
![İletişim Mesajları](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-contact-all.png?raw=true)
#### Yazarlar
![Yazarlar](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-author.png?raw=true)
#### Kategoriler
![Yöneticiler](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-category.png?raw=true)
#### Yorumlar
![Yöneticiler](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-comment-all.png?raw=true)
#### Bildirimler
![Bildirimler](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-notification.png?raw=true)
#### Etiketler
![Etiketler](https://github.com/batuhanyalin/MyBlog/blob/master/MyBlog.PresentationLayer/wwwroot/projectScreenshots/admin-tag.png?raw=true)
