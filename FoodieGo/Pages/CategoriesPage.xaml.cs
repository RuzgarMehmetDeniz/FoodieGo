using FoodieGo.Models;
using FoodieGo.Services;

namespace FoodieGo.Pages
{
    public class CategoryDisplayItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Emoji { get; set; }
        public int ProductCount { get; set; }
    }

    public partial class CategoriesPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public CategoriesPage()
        {
            InitializeComponent();

            _databaseService = new DatabaseService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await LoadCategoriesAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                List<Category> categories =
                    await _databaseService.GetCategoriesAsync();

                List<CategoryDisplayItem> items =
                    categories.Select(c => new CategoryDisplayItem
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Emoji = c.Icon,
                        ProductCount = c.ProductCount
                    }).ToList();

                CategoriesList.ItemsSource = items;
            }
            catch (Exception ex)
            {
                await DisplayAlert(
                    "Hata",
                    $"Kategoriler yüklenirken hata oluştu:\n{ex.Message}",
                    "Tamam");
            }
        }

        private async void CategoriesList_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            CategoryDisplayItem selectedCategory =
                e.CurrentSelection.FirstOrDefault() as CategoryDisplayItem;

            if (selectedCategory == null)
                return;

            // Seçimi temizle
            CategoriesList.SelectedItem = null;

            // Kategoriye ait ürünleri aç
            await Navigation.PushAsync(
                new ProductsPage(
                    selectedCategory.Id,
                    selectedCategory.Name));
        }
    }
}