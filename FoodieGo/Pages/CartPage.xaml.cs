using FoodieGo.Models;
using FoodieGo.Services;
using System.Linq;

namespace FoodieGo.Pages
{
    public partial class CartPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public CartPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadCartAsync();
        }

        private async Task LoadCartAsync()
        {
            try
            {
                List<CartDisplayItem> items = await _databaseService.GetCartDisplayItemsAsync();

                CartList.ItemsSource = items;

                decimal total = items.Sum(i => i.LineTotal);
                TotalLabel.Text = $"{total:0.00} TL";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", $"Sepet yüklenirken bir sorun oluştu: {ex.Message}", "Tamam");
            }
        }

        private async void OnIncreaseTapped(object sender, EventArgs e)
        {
            if (sender is not Label label)
                return;

            if (label.GestureRecognizers.FirstOrDefault() is not TapGestureRecognizer tap)
                return;

            if (tap.CommandParameter is not int productId)
                return;

            await _databaseService.AddToCartAsync(productId);
            await LoadCartAsync();
        }

        private async void OnDecreaseTapped(object sender, EventArgs e)
        {
            if (sender is not Label label)
                return;

            if (label.GestureRecognizers.FirstOrDefault() is not TapGestureRecognizer tap)
                return;

            if (tap.CommandParameter is not int productId)
                return;

            await _databaseService.RemoveFromCartAsync(productId);
            await LoadCartAsync();
        }
    }
}