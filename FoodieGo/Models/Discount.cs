using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieGo.Models
{
    public class Discount
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Percentage { get; set; }    // 30  → "%30"

        [MaxLength(100)]
        public string Title { get; set; }       // "Haftanın Fırsatları"

        [MaxLength(200)]
        public string Description { get; set; } // "Seçili ürünlerde geçerli süper indirim"

        public string EndDate { get; set; }     // "30 Ağustos" (şimdilik metin)

        public string Color { get; set; }       // "#006C49" (banner arka plan rengi)
        public string Image { get; set; }      
    }
}
