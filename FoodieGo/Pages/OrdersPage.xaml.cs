using FoodieGo.Services;

namespace FoodieGo.Pages
{
    public partial class OrdersPage : ContentPage
    {
        private readonly DatabaseService _db = new DatabaseService();

        public OrdersPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadOrdersAsync();
        }

        private async Task LoadOrdersAsync()
        {
            var user = SessionService.CurrentUser;

            if (user == null)
                return;

            var orders = await _db.GetOrdersForUserAsync(user.Id);

            OrdersList.ItemsSource = orders;
            OrderCountLabel.Text = $"{orders.Count} sipariş";
        }

        private async void OnBackTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}