using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieGo.Models
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }      // "Meyve & Sebze"

        public string Icon { get; set; }       // emoji veya ikon kodu: "🍎"

        public int ProductCount { get; set; }  // "120+ ürün" için sayı: 120

    }
}
