using FoodieGo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieGo.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _db;

        // Veritabanı dosyasının sabit masaüstü yolu
        private const string DbPath = @"C:\Users\Acer\OneDrive\Masaüstü\DbFoodieGo.db";
        private async Task Init()
        {
            if (_db is not null)
                return;

            // Dosya gerçekten var mı diye kontrol et (yoksa anlaşılır hata ver)
            if (!File.Exists(DbPath))
                throw new FileNotFoundException($"Veritabanı bulunamadı: {DbPath}");

            // Salt okunur olarak aç (sadece listeleyeceğiz)
            _db = new SQLiteAsyncConnection(DbPath);

            // async imzasını korumak için (bu metotta await yok)
            await Task.CompletedTask;
        }

        // ---------- LİSTELEME (sadece okuma) ----------

        public async Task<List<Discount>> GetDiscountsAsync()
        {
            await Init();
            return await _db.Table<Discount>().ToListAsync();
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            await Init();
            return await _db.Table<Category>().ToListAsync();
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            await Init();
            return await _db.Table<Product>().ToListAsync();
        }

        // Sepete ürün ekle (zaten varsa adedini artır)
        public async Task AddToCartAsync(int productId)
        {
            await Init();

            // Bu ürün sepette var mı?
            CartItem existing = await _db.Table<CartItem>()
                                         .Where(c => c.ProductId == productId)
                                         .FirstOrDefaultAsync();

            if (existing is null)
            {
                // Yoksa yeni satır ekle (adet 1)
                await _db.InsertAsync(new CartItem { ProductId = productId, Quantity = 1 });
            }
            else
            {
                // Varsa adedini 1 artır
                existing.Quantity++;
                await _db.UpdateAsync(existing);
            }
        }

        // Sepetten çıkar (adedi azalt, 1'ken tamamen sil)
        public async Task RemoveFromCartAsync(int productId)
        {
            await Init();

            CartItem existing = await _db.Table<CartItem>()
                                         .Where(c => c.ProductId == productId)
                                         .FirstOrDefaultAsync();

            if (existing is null)
                return; // sepette yoksa yapacak bir şey yok

            if (existing.Quantity > 1)
            {
                // Adet 1'den fazlaysa azalt
                existing.Quantity--;
                await _db.UpdateAsync(existing);
            }
            else
            {
                // Adet 1'se satırı tamamen sil
                await _db.DeleteAsync(existing);
            }
        }

        // Sepetteki tüm satırları getir
        public async Task<List<CartItem>> GetCartItemsAsync()
        {
            await Init();
            return await _db.Table<CartItem>().ToListAsync();
        }

        // Sepeti ürün detaylarıyla birlikte getir (ekranda göstermek için)
        public async Task<List<CartDisplayItem>> GetCartDisplayItemsAsync()
        {
            await Init();

            List<CartItem> cartItems = await _db.Table<CartItem>().ToListAsync();
            List<Product> products = await _db.Table<Product>().ToListAsync();

            var result = new List<CartDisplayItem>();

            foreach (CartItem item in cartItems)
            {
                // Bu sepet satırının ürününü bul
                Product product = products.FirstOrDefault(p => p.Id == item.ProductId);
                if (product is null)
                    continue; // ürün bulunamazsa atla

                result.Add(new CartDisplayItem
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

    }
}