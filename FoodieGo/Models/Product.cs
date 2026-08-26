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
        public string Name { get; set; }

        public string Unit { get; set; }

        public decimal Price { get; set; }

        public decimal OldPrice { get; set; }

        public string Image { get; set; }

        public string Badge { get; set; }

        public int CategoryId { get; set; }
    }

}
