using FoodieGo.Models;
using SQLite;

namespace FoodieGo.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _db;

        // DB Browser'da kullandığın veritabanının yolu
        private const string DbPath =
            @"C:\Users\Acer\OneDrive\Masaüstü\DbFoodieGo.db";

        // =========================
        // VERİTABANI BAŞLATMA
        // =========================
        private async Task Init()
        {
            if (_db is not null)
                return;

            // Masaüstündeki DbFoodieGo.db dosyasını kullan
            _db = new SQLiteAsyncConnection(DbPath);

            // Tablolar yoksa oluştur
            await _db.CreateTableAsync<Category>();
            await _db.CreateTableAsync<Product>();
            await _db.CreateTableAsync<Discount>();
            await _db.CreateTableAsync<CartItem>();
            await _db.CreateTableAsync<User>();

        }


        // =========================
        // KATEGORİLER
        // =========================
        public async Task<List<Category>> GetCategoriesAsync()
        {
            await Init();

            return await _db
                .Table<Category>()
                .ToListAsync();
        }


        // =========================
        // TÜM ÜRÜNLER
        // =========================
        public async Task<List<Product>> GetProductsAsync()
        {
            await Init();

            var products = await _db
                .Table<Product>()
                .ToListAsync();

            System.Diagnostics.Debug.WriteLine(
                $"========== PRODUCT SAYISI: {products.Count} ==========");

            foreach (var product in products)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"ID: {product.Id} | {product.Name} | {product.Price} TL | CategoryId: {product.CategoryId}");
            }

            return products;
        }


        // =========================
        // KATEGORİYE GÖRE ÜRÜNLER
        // =========================
        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            await Init();

            return await _db
                .Table<Product>()
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }


        // =========================
        // İNDİRİMLER
        // =========================
        public async Task<List<Discount>> GetDiscountsAsync()
        {
            await Init();

            return await _db
                .Table<Discount>()
                .ToListAsync();
        }


        // =========================
        // SEPETE ÜRÜN EKLE
        // =========================
        public async Task AddToCartAsync(int productId)
        {
            await Init();

            CartItem existing = await _db
                .Table<CartItem>()
                .Where(c => c.ProductId == productId)
                .FirstOrDefaultAsync();

            if (existing == null)
            {
                // Ürün sepette yoksa yeni kayıt oluştur
                await _db.InsertAsync(
                    new CartItem
                    {
                        ProductId = productId,
                        Quantity = 1
                    });
            }
            else
            {
                // Ürün zaten varsa adedini artır
                existing.Quantity++;

                await _db.UpdateAsync(existing);
            }
        }


        // =========================
        // SEPETTEN ÜRÜN ÇIKAR
        // =========================
        public async Task RemoveFromCartAsync(int productId)
        {
            await Init();

            CartItem existing = await _db
                .Table<CartItem>()
                .Where(c => c.ProductId == productId)
                .FirstOrDefaultAsync();

            if (existing == null)
                return;

            if (existing.Quantity > 1)
            {
                // Adet 1'den fazlaysa azalt
                existing.Quantity--;

                await _db.UpdateAsync(existing);
            }
            else
            {
                // Adet 1 ise ürünü tamamen sil
                await _db.DeleteAsync(existing);
            }
        }


        // =========================
        // SEPETTEKİ ÜRÜNLER
        // =========================
        public async Task<List<CartItem>> GetCartItemsAsync()
        {
            await Init();

            return await _db
                .Table<CartItem>()
                .ToListAsync();
        }


        // =========================
        // SEPET ÜRÜNLERİ + ÜRÜN DETAYLARI
        // =========================
        public async Task<List<CartDisplayItem>> GetCartDisplayItemsAsync()
        {
            await Init();

            List<CartItem> cartItems =
                await _db
                    .Table<CartItem>()
                    .ToListAsync();

            List<Product> products =
                await _db
                    .Table<Product>()
                    .ToListAsync();

            List<CartDisplayItem> result =
                new List<CartDisplayItem>();

            foreach (CartItem item in cartItems)
            {
                Product product =
                    products.FirstOrDefault(
                        p => p.Id == item.ProductId);

                if (product == null)
                    continue;

                result.Add(
                    new CartDisplayItem
                    {
                        ProductId = product.Id,
                        Name = product.Name,
                        Image = product.Image,
                        Price = product.Price,
                        Quantity = item.Quantity
                    });
            }

            return result;
        }

        public async Task<StatisticsData> GetStatisticsAsync()
        {
            await Init();

            var products = await _db.Table<Product>().ToListAsync();
            var categories = await _db.Table<Category>().ToListAsync();
            var discounts = await _db.Table<Discount>().ToListAsync();
            var cartItems = await _db.Table<CartItem>().ToListAsync();
            var cartDisplayItems = await GetCartDisplayItemsAsync();

            var categoryStats = categories.Select(cat =>
            {
                int count = products.Count(p => p.CategoryId == cat.Id);
                double percentage = products.Count == 0
                    ? 0
                    : Math.Round((double)count / products.Count * 100, 0);

                return new CategoryProductStat
                {
                    Name = cat.Name,
                    ProductCount = count,
                    Percentage = percentage
                };
            })
            .OrderByDescending(c => c.ProductCount)
            .ToList();

            return new StatisticsData
            {
                TotalProductCount = products.Count,
                CartItemCount = cartItems.Sum(c => c.Quantity),
                CartTotal = cartDisplayItems.Sum(c => c.Price * c.Quantity),
                ActiveDiscountCount = discounts.Count,

                TotalCategoryCount = categories.Count,
                AverageProductPrice = products.Count == 0 ? 0 : products.Average(p => p.Price),
                DistinctCartProductCount = cartItems.Select(c => c.ProductId).Distinct().Count(),
                MaxDiscountRate = discounts.Count == 0 ? 0 : discounts.Max(d => d.Percentage), // Discount'ta Rate alanın neyse ona göre uyarlarız

                CategoryDistribution = categoryStats
            };
        }
        // =========================
        // KAYIT OL
        // =========================
        public async Task<bool> RegisterAsync(string fullName, string email, string password)
        {
            await Init();

            var existing = await _db.Table<User>()
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();

            if (existing != null)
                return false; // Bu e-posta zaten kayıtlı

            await _db.InsertAsync(new User
            {
                FullName = fullName,
                Email = email,
                Password = password
            });

            return true;
        }

        // =========================
        // GİRİŞ YAP
        // =========================
        public async Task<User> LoginAsync(string email, string password)
        {
            await Init();

            return await _db.Table<User>()
                .Where(u => u.Email == email && u.Password == password)
                .FirstOrDefaultAsync();
        }
    }
}
