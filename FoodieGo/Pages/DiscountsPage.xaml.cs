using FoodieGo.Models;
using FoodieGo.Services;

namespace FoodieGo.Pages
{
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
        private readonly DatabaseService _databaseService;

        public DiscountsPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadDiscountsAsync();
        }

        private async Task LoadDiscountsAsync()
        {
            try
            {
                List<Discount> discounts = await _databaseService.GetDiscountsAsync();

                List<DiscountDisplayItem> items = discounts.Select(d => new DiscountDisplayItem
                {
                    Percentage = d.Percentage,
                    Title = d.Title,
                    Description = d.Description,
                    EndDate = d.EndDate,
                    BackgroundColor = Color.FromArgb(d.Color)
                }).ToList();

                DiscountsList.ItemsSource = items;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", $"Ýndirimler yüklenirken hata oluþtu:\n{ex.Message}", "Tamam");
            }
        }

        private async void OnBackTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}