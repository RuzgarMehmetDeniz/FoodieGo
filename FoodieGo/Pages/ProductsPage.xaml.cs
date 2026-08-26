using System.Collections.ObjectModel;

namespace FoodieGo.Pages
{
    // Geçici görüntüleme sınıfı - DB bağlanınca Models/Product kullanılacak
    public class ProductDisplayItem
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public string Emoji { get; set; }
    }

    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();

            var demoProducts = new ObservableCollection<ProductDisplayItem>
            {
                new() { Name = "Elma (Kg)", Unit = "1 kg", Price = 34.90m, Emoji = "🍎" },
                new() { Name = "Tam Yağlı Süt", Unit = "1 L", Price = 27.50m, Emoji = "🥛" },
                new() { Name = "Ekmek", Unit = "1 adet", Price = 12.00m, Emoji = "🥖" },
                new() { Name = "Portakal Suyu", Unit = "1 L", Price = 39.90m, Emoji = "🧃" },
                new() { Name = "Muz (Kg)", Unit = "1 kg", Price = 44.90m, Emoji = "🍌" },
                new() { Name = "Yumurta (15'li)", Unit = "1 koli", Price = 89.90m, Emoji = "🥚" },
            };

            ProductsList.ItemsSource = demoProducts;

            // Case Görev 6: başlıkta toplam ürün sayısı dinamik gösterilmeli
            ProductCountLabel.Text = $"{demoProducts.Count} ürün";
        }
    }
}