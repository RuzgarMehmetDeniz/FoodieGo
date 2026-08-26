using System.Collections.ObjectModel;

namespace FoodieGo.Pages
{
    // Geçici görüntüleme sýnýfý - DB baðlanýnca gerçek sorgulardan (Order/Product) hesaplanacak
    public class CategoryStatDisplayItem
    {
        public string Name { get; set; }
        public int Percentage { get; set; }

        // Yüzdeyi ekranda görsel çubuk geniþliðine çevirir (yaklaþýk, sabit bir çarpan)
        public double BarWidth => Percentage * 2;
    }

    public partial class StatisticsPage : ContentPage
    {
        public StatisticsPage()
        {
            InitializeComponent();

            CategoryStatsList.ItemsSource = new ObservableCollection<CategoryStatDisplayItem>
            {
                new() { Name = "Meyve & Sebze", Percentage = 34 },
                new() { Name = "Süt Ürünleri", Percentage = 22 },
                new() { Name = "Ýçecekler", Percentage = 18 },
                new() { Name = "Atýþtýrmalýk", Percentage = 15 },
                new() { Name = "Fýrýn", Percentage = 11 },
            };
        }

        private async void OnBackTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}