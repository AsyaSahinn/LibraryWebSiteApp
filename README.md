# Kütüphane Uygulaması

Bu ASP.NET Core MVC tabanlı uygulama, bir kütüphane yönetim sistemini simüle eder. Kullanıcılar kitapları listeleme, kitap detaylarını görüntüleme ve kitap ödünç alma işlemlerini gerçekleştirebilir.

## Ana Sayfa

Ana sayfa, tüm kitapları listeler. Her kitap için adı, resmi ve ödünç alınıp alınmadığı bilgisi görüntülenir. Kitapların yanındaki "Details" butonuna tıklanarak, ödünç alınmışsa ödünç alma bilgilerini içeren bir sayfaya gidilir. Eğer ödünç alınmamışsa, ödünç alma formu gösterilir.

## Kitap Ekleme

Ana sayfada bulunan "Add Book" butonuna tıklandığında, kullanıcı "Add Book" sayfasına yönlendirilir. Bu sayfada, kitabın adı, yazarı ve resmi girilir. Resim yükleme işlemi de burada gerçekleştirilir. Form gönderildiğinde yeni kitap veritabanına eklenir.

## Ödünç Alma ve Detaylar

Kitapların detaylarını görmek için "Details" butonuna tıklanır. Eğer kitap ödünç alınmışsa, ödünç alma bilgileri görüntülenir. Eğer ödünç alınmamışsa, ödünç alma formu gösterilir ve kullanıcı kitabı ödünç alabilir.

## Kurulum

1. Bu projeyi klonlayın: `git clone https://github.com/username/repo.git`
2. Proje dizinine gidin: `cd repo`
3. `appsettings.json` dosyasında veritabanı bağlantı ayarlarınızı düzenleyin.
4. Proje dizininde terminali açın ve aşağıdaki komutları çalıştırın:
5. Tarayıcıda `http://localhost:port` adresine giderek uygulamayı görüntüleyin.

## Teknolojiler

- ASP.NET Core MVC
- Entity Framework Core
- HTML, CSS, JavaScript
- ...
