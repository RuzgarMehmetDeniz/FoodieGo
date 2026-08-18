using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieGo.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }       // "Domates Salkım"

        public string Unit { get; set; }        // "1 kg", "Adet", "400 g"

        public decimal Price { get; set; }      // 54.90

        public decimal OldPrice { get; set; }   // indirim öncesi fiyat (yoksa 0)

        public string Image { get; set; }       // görsel adı veya emoji

        public string Badge { get; set; }       // "Çok Satan", "Yeni Sezon" (yoksa boş)

        // İlişki: bu ürün hangi kategoriye ait
        public int CategoryId { get; set; }
    }

}
