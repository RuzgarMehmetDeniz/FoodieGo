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
    }
}