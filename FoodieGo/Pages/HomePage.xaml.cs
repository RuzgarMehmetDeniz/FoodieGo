using FoodieGo.Models;
using FoodieGo.Services;
using System.Linq;

namespace FoodieGo.Pages
{
    public partial class HomePage : ContentPage
    {
        private readonly DatabaseService _databaseService = new DatabaseService();

        public HomePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadCategoriesAsync();
            await LoadFeaturedProductsAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            var categories = await _databaseService.GetCategoriesAsync();
            CategoriesList.ItemsSource = categories;
        }

        private async Task LoadFeaturedProductsAsync()
        {
            var products = await _databaseService.GetProductsAsync();
            ProductCountLabel.Text = $"{products.Count} ürün";
            FeaturedProductsList.ItemsSource = products.Take(8).ToList();
        }

        private async void OnDiscountsBannerTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DiscountsPage());
        }

        private async void OnAllProductsTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductsPage());
        }

        private async void OnCategoryTapped(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new CategoriesPage());
        }

        private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string query = e.NewTextValue?.Trim();
            ClearSearchLabel.IsVisible = !string.IsNullOrWhiteSpace(query);

            if (string.IsNullOrWhiteSpace(query))
            {
                SearchResultsSection.IsVisible = false;
                DefaultContentSection.IsVisible = true;
                return;
            }

            DefaultContentSection.IsVisible = false;
            SearchResultsSection.IsVisible = true;

            List<Product> results = await _databaseService.SearchProductsAsync(query);
            SearchResultsCountLabel.Text = $"{results.Count} sonuç";
            SearchResultsList.ItemsSource = results;
        }

        private void OnClearSearchTapped(object sender, EventArgs e)
        {
            SearchEntry.Text = string.Empty;
        }

        private async void OnSearchResultAddTapped(object sender, EventArgs e)
        {
            if (sender is not Label label)
                return;
            if (label.GestureRecognizers.FirstOrDefault() is not TapGestureRecognizer tap)
                return;
            if (tap.CommandParameter is not int productId)
                return;

            await _databaseService.AddToCartAsync(productId);
            await DisplayAlert("Sepete Eklendi", "Ürün sepetine eklendi.", "Tamam");
        }
    }
}