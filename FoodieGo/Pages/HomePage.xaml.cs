namespace FoodieGo.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnDiscountsBannerTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DiscountsPage());
        }

        private async void OnAllProductsTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductsPage());
        }
    }
}