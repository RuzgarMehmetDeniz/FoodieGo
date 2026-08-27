# FoodieGo 🍔

**FoodieGo**, Getir / Migros Yemek / Trendyol Go tarzı bir **market & hızlı teslimat** mobil uygulamasının .NET MAUI ile geliştirilmiş halidir. SQLite veritabanından okuyan, kullanıcı etkileşimli bir sepet mekanizması içeren ve sayfalar arası gezinme sağlayan bir mobil uygulama olarak geliştirilmiştir.

## 📱 Özellikler

- **Ana Sayfa** — canlı arama, kampanya banner'ları, kategoriler ve öne çıkan ürünler (tümü veritabanından dinamik)
- **Kategoriler** — veritabanından gelen kategori listesi, seçilen kategoriye göre ürün filtreleme
- **Ürünler** — iki sütunlu ürün ızgarası, sepete hızlı ekleme, toplam ürün sayısı
- **Ürün Detay** — ürün görseli/adı/fiyatı, adet seçimi, sepete ekleme
- **Sepet** — adet artırma/azaltma, canlı toplam tutar, boş sepet ekranı
- **Siparişlerim** — geçmiş siparişlerin listesi
- **İndirimler** — aktif indirimlerin gerçek görsel + koyu katman ile gösterimi
- **İstatistikler** — toplam ürün/kategori sayısı, sepet özeti, aktif indirim sayısı, kategori dağılımı
- **Profil** — kullanıcı bilgisi, siparişlerim/istatistiklerim bağlantıları, çıkış yap
- **Giriş / Kayıt Ol** — e-posta ve şifre ile kullanıcı girişi ve kayıt

## 🛠️ Teknolojiler

- **.NET MAUI** (XAML + code-behind)
- **SQLite** (`sqlite-net-pcl`) — tüm veritabanı erişimi `DatabaseService` sınıfında toplanmıştır
- **Shell (TabBar)** — alt navigasyon ve sayfalar arası geçiş
- Özel font (Inter, OpenSans) ve ikon fontu (Material Symbols) entegrasyonu

## 🗄️ Veritabanı Şeması

| Tablo | Açıklama |
|---|---|
| `Category` | Ürün kategorileri (ad, ikon, ürün sayısı) |
| `Product` | Ürünler (ad, birim, fiyat, eski fiyat, görsel, kategori referansı) |
| `Discount` | Aktif indirimler |
| `CartItem` | Sepetteki ürünler (ürün referansı + adet) |
| `User` | Kayıtlı kullanıcılar |
| `Order` / `OrderItem` | Tamamlanmış siparişler ve sipariş kalemleri |


## 📂 Proje Yapısı

```
FoodieGo/
├── Models/          # Category, Product, Discount, CartItem, User, Order, OrderItem
├── Pages/           # HomePage, CategoriesPage, ProductsPage, ProductDetailPage,
│                    # CartPage, OrdersPage, DiscountsPage, StatisticsPage,
│                    # ProfilePage, LoginPage, RegisterPage
├── Services/        # DatabaseService, SessionService
├── Helpers/         # IconFont
├── Resources/       # Fonts, Images, Styles (Colors.xaml)
└── AppShell.xaml    # Alt navigasyon (TabBar) ve sayfa yönlendirmeleri
```

## 📝 Notlar

- Kategoriye tıklandığında sadece o kategoriye ait ürünler listelenir (parametreli gezinme).
- Ürün kartına tıklandığında ürünün gerçek verileriyle Ürün Detay sayfası açılır.
- Sepetteki adet güncellemeleri ve toplam tutar anlık olarak yansıtılır.


# <img width="580" height="732" alt="Register" src="https://github.com/user-attachments/assets/3d72b3ea-c754-436a-8dff-36bff5a40d2b" />
# <img width="580" height="732" alt="Login" src="https://github.com/user-attachments/assets/85f81d28-511b-40ba-bf63-f735bef3aaf5" />
# <img width="549" height="982" alt="Home" src="https://github.com/user-attachments/assets/2b66eb64-6e38-41a8-87b9-cebfcb82a8b2" />
# <img width="669" height="782" alt="Discount" src="https://github.com/user-attachments/assets/63d72d07-576b-4a94-b37b-5346df607bfd" />
# <img width="545" height="1396" alt="Category" src="https://github.com/user-attachments/assets/043513dc-0bd7-4d24-ad96-b59c865801f6" />
# <img width="548" height="729" alt="CategoryProduct" src="https://github.com/user-attachments/assets/54851897-7869-4537-915c-28bfd4420229" />
# <img width="548" height="748" alt="Product" src="https://github.com/user-attachments/assets/0a2c56a4-2db3-4317-984f-7a268e3f7a47" />
# <img width="669" height="782" alt="ProductDetail" src="https://github.com/user-attachments/assets/19a8b3db-f425-404f-bec0-a726fb3330d4" />
# <img width="548" height="748" alt="Basket" src="https://github.com/user-attachments/assets/d986e296-54ee-40f2-b25b-0368da7f1401" />
# <img width="548" height="884" alt="Profile" src="https://github.com/user-attachments/assets/159fbdbf-87fb-4027-8194-4e6ca7a6813a" />
# <img width="548" height="884" alt="BasketProfile" src="https://github.com/user-attachments/assets/5886c24c-3e57-42b2-8348-a27da006fb71" />
# <img width="548" height="884" alt="Statistic1" src="https://github.com/user-attachments/assets/7fe8d6bb-b08f-4fab-a35c-4ce0ee3c950b" />
# <img width="548" height="884" alt="Statistic2" src="https://github.com/user-attachments/assets/78aeac84-c525-480a-89f1-010614efbb0d" />
