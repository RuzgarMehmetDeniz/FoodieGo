using FoodieGo.Models;
using FoodieGo.Services;

namespace FoodieGo.Pages
{
    public partial class ProductsPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public ProductsPage()
        {
            InitializeComponent();

            _databaseService = new DatabaseService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await LoadProductsAsync();
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                List<Product> products =
                    await _databaseService.GetProductsAsync();

                ProductsList.ItemsSource = products;

                ProductCountLabel.Text =
                    $"{products.Count} ürün";
            }
            catch (Exception ex)
            {
                await DisplayAlert(
                    "Hata",
                    $"Ürünler yüklenirken hata oluştu:\n{ex.Message}",
                    "Tamam");
            }
        }
    }
}
