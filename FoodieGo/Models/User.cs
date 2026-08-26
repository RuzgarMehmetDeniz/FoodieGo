using SQLite;

namespace FoodieGo.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Password { get; set; } // Not: case projesi olduğu için düz metin, gerçek üründe hashlenmeli
    }
}