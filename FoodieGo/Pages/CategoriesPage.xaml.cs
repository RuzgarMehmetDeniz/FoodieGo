using System.Collections.ObjectModel;

namespace FoodieGo.Pages
{
    // Geçici görüntüleme sınıfı - DB bağlanınca Models/Category kullanılacak
    public class CategoryDisplayItem
    {
        public string Name { get; set; }
        public string Emoji { get; set; }
    }

    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage()
        {
            InitializeComponent();

            CategoriesList.ItemsSource = new ObservableCollection<CategoryDisplayItem>
            {
                new() { Name = "Meyve & Sebze", Emoji = "🍎" },
                new() { Name = "Süt Ürünleri", Emoji = "🥛" },
               new() { Name = "Fırın", Emoji = "🍞" },
                new() { Name = "İçecekler", Emoji = "🥤" },
                new() { Name = "Atıştırmalık", Emoji = "🍿" },
                new() { Name = "Temizlik", Emoji = "🧴" },
            };
        }
    }
}