using System.Collections.ObjectModel;
using System.Linq;

namespace FoodieGo.Pages
{
    // Geçici görüntüleme sınıfı - DB bağlanınca CartDisplayItem (Models) kullanılacak
    public class CartDisplayItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Emoji { get; set; }
    }

    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();

            var demoCart = new ObservableCollection<CartDisplayItem>
            {
                new() { Name = "Elma (Kg)", Price = 34.90m, Quantity = 2, Emoji = "🍎" },
                new() { Name = "Tam Yağlı Süt", Price = 27.50m, Quantity = 1, Emoji = "🥛" },
            };

            CartList.ItemsSource = demoCart;

            // Case kuralı: sepet toplamı verilerden hesaplanmalı
            decimal total = demoCart.Sum(i => i.Price * i.Quantity);
            TotalLabel.Text = $"{total:0.00} TL";
        }
    }
}