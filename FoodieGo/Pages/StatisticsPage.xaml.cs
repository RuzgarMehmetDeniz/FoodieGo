using FoodieGo.Services;

namespace FoodieGo.Pages
{
    public partial class StatisticsPage : ContentPage
    {
        private readonly DatabaseService _db = new DatabaseService();

        public StatisticsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadStatisticsAsync();
        }

        private async Task LoadStatisticsAsync()
        {
            var stats = await _db.GetStatisticsAsync();

            // Ana KPI'lar
            TotalProductLabel.Text = stats.TotalProductCount.ToString();
            CartItemCountLabel.Text = stats.CartItemCount.ToString();
            CartTotalLabel.Text = stats.CartTotal.ToString("C2");
            ActiveDiscountLabel.Text = stats.ActiveDiscountCount.ToString();

            // Ek detaylar
            TotalCategoryLabel.Text = stats.TotalCategoryCount.ToString();
            AvgPriceLabel.Text = stats.AverageProductPrice.ToString("C2");
            DistinctCartLabel.Text = stats.DistinctCartProductCount.ToString();
            MaxDiscountLabel.Text = $"%{stats.MaxDiscountRate}";

            // Kategori daðýlýmý
            CategoryStatsList.ItemsSource = stats.CategoryDistribution;
            EmptyCategoryLabel.IsVisible = stats.CategoryDistribution == null || stats.CategoryDistribution.Count == 0;
        }

        private async void OnBackTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}