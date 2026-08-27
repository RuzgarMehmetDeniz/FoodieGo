using SQLite;

namespace FoodieGo.Models
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string OrderDate { get; set; } // "dd.MM.yyyy HH:mm" formatında metin

        public decimal Total { get; set; }
    }
}