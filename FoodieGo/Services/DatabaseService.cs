using SQLite;
using FoodieGo.Models;

namespace FoodieGo.Services;

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
        _db = new SQLiteAsyncConnection(DbPath, SQLiteOpenFlags.ReadOnly);

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
}

