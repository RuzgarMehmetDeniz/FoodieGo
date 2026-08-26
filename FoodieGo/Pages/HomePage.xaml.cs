using FoodieGo.Pages;

namespace FoodieGo.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        // Haftanýn Fýrsatlarý bannerýna basýnca
        // Ýndirimler sayfasýna gider
        private async void OnDiscountsBannerTapped(
            object sender,
            TappedEventArgs e)
        {
            await Shell.Current.GoToAsync(
                nameof(DiscountsPage));
        }

        // Tümünü Gör'e basýnca
        // Ürünler sayfasýna gider
        private async void OnAllProductsTapped(
            object sender,
            TappedEventArgs e)
        {
            await Shell.Current.GoToAsync(
                nameof(ProductsPage));
        }
    }
}
