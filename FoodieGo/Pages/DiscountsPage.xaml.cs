using System.Collections.ObjectModel;

namespace FoodieGo.Pages
{
    // Geçici görüntüleme sýnýfý - DB baðlanýnca Models/Discount kullanýlacak
    public class DiscountDisplayItem
    {
        public int Percentage { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EndDate { get; set; }
        public Color BackgroundColor { get; set; }
    }

    public partial class DiscountsPage : ContentPage
    {
        public DiscountsPage()
        {
            InitializeComponent();

            DiscountsList.ItemsSource = new ObservableCollection<DiscountDisplayItem>
            {
                new()
                {
                    Percentage = 30,
                    Title = "Haftanýn Fýrsatlarý",
                    Description = "Seçili ürünlerde geçerli süper indirim",
                    EndDate = "30 Aðustos",
                    BackgroundColor = (Color)Application.Current.Resources["Primary"]
                },
                new()
                {
                    Percentage = 15,
                    Title = "Meyve & Sebzede Ýndirim",
                    Description = "Taze ürünlerde kaçýrýlmayacak fýrsat",
                    EndDate = "2 Eylül",
                    BackgroundColor = (Color)Application.Current.Resources["SecondaryDarkText"]
                },
                new()
                {
                    Percentage = 20,
                    Title = "Ýlk Sipariþe Özel",
                    Description = "Yeni üyelere özel indirim kodu",
                    EndDate = "10 Eylül",
                    BackgroundColor = (Color)Application.Current.Resources["DiscountRed"]
                },
            };
        }

        private async void OnBackTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}