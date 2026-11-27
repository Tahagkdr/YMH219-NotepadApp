# YMH219-NotepadApp

Nesne Tabanlı Programlama (YMH 219) dersi için hazırlanmış bir not defteri uygulamasıdır. Amacı, notları dosya işlemleri ve serileştirme ile kalıcı olarak saklamaktır. Uygulama kapatılıp açılsa bile notlar korunur.

## Kullanılan Teknolojiler

- C# / .NET (Windows Forms)
- System.Text.Json (JSON serileştirme)
- System.IO (dosya işlemleri)
- Visual Studio, Git ve GitHub
- Ek NuGet paketi kullanılmamıştır.

## Kurulum ve Çalıştırma

1. Depoyu klonlayın: `git clone https://github.com/Tahagkdr/YMH219-NotepadApp.git`
2. `NotepadApp` klasöründeki `NotepadApp.slnx` dosyasını Visual Studio ile açın.
3. Gerekli .NET SDK sürümünün kurulu olduğundan emin olun (sürüm `NotepadApp.csproj` dosyasında yazar).
4. `F5` tuşuna basarak uygulamayı çalıştırın.

## Temel Özellikler

- Not ekleme, listeleme, düzenleme ve silme (silmeden önce onay sorulur)
- Notların JSON dosyasına kaydedilmesi ve açılışta otomatik yüklenmesi
- Notu `.txt` olarak dışa aktarma
- Her notun oluşturma ve düzenleme tarihinin tutulması
- Bozuk veya erişilemeyen dosya durumları için hata yönetimi

## Proje Yapısı

| Dosya | Görevi |
|---|---|
| `Not.cs` | Not sınıfı |
| `NotDeposu.cs` | JSON kaydetme ve yükleme |
| `Form1.cs` | Buton ve liste olayları |
| `Form1.Designer.cs` | Form tasarımı |

Notların kaydedildiği dosya: `%APPDATA%\YMH219-NotepadApp\notlar.json`

## Ekran Görüntüleri

### Ana ekran
![Ana ekran](ekran1.jpeg)

### Silme onayı
![Silme onayı](ekran2.jpeg)

## Bilinen Sınırlamalar / Geliştirme Notları

- Arama ve filtreleme özelliği yoktur.
- Kategori veya etiket desteği yoktur.
- Metin biçimlendirmesi kaydedilmez, yalnızca düz metin saklanır.
- Kaydedilmemiş değişiklikler, başka bir nota geçilirse uyarı verilmeden kaybolur.

## Öğrenci

- **Ad Soyad:** Muhammed Taha Gökdere
- **Öğrenci Numarası:** 250541092