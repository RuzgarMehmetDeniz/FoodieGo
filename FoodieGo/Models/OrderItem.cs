using SQLite;

namespace FoodieGo.Models
{
    public class OrderItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        [MaxLength(150)]
        public string ProductName { get; set; } // Sipariş anındaki ürün adı (ürün silinse/değişse bile bozulmaz)

        public decimal Price { get; set; } // Sipariş anındaki fiyat

        public int Quantity { get; set; }
    }
}