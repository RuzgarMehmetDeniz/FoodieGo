using FoodieGo.Services;
namespace FoodieGo.Pages
{
    public partial class ProductsPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private readonly int? _categoryId;

        public ProductsPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            _categoryId = null;
        }

        public ProductsPage(int categoryId, string categoryName)
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            _categoryId = categoryId;
            if (!string.IsNullOrEmpty(categoryName))
            {
                Title = categoryName;
            }
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
                var products = _categoryId.HasValue
                    ? await _databaseService.GetProductsByCategoryAsync(_categoryId.Value)
                    : await _databaseService.GetProductsAsync();
                ProductsList.ItemsSource = products;
                ProductCountLabel.Text = $"{products.Count} Ürün";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", $"Ürünler yüklenirken bir sorun oluştu: {ex.Message}", "Tamam");
            }
        }

        private async void OnAddToCartClicked(object sender, EventArgs e)
        {
            if (sender is not Button button)
                return;

            if (button.CommandParameter is not int productId)
                return;

            try
            {
                await _databaseService.AddToCartAsync(productId);
                await ShowToastAsync("Sepete eklendi");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", $"Ürün sepete eklenirken bir sorun oluştu: {ex.Message}", "Tamam");
            }
        }

        private async Task ShowToastAsync(string message)
        {
            ToastLabel.Text = message;
            ToastBorder.IsVisible = true;

            await ToastBorder.FadeTo(1, 150);
            await Task.Delay(1200);
            await ToastBorder.FadeTo(0, 150);

            ToastBorder.IsVisible = false;
        }
    }
}