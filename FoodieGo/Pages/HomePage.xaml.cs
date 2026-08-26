namespace FoodieGo.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnDiscountsBannerTapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(DiscountsPage));
        }
    }
}