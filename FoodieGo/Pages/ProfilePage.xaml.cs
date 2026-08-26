namespace FoodieGo.Pages
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private async void OnStatisticsTapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(StatisticsPage));
        }
    }
}