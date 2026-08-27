using FoodieGo.Services;

namespace FoodieGo.Pages
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var user = SessionService.CurrentUser;

            if (user != null)
            {
                UserNameLabel.Text = user.FullName;
                UserEmailLabel.Text = user.Email;
            }
        }

        private async void OnStatisticsTapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(StatisticsPage));
        }

        private async void OnOrdersTapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(OrdersPage));
        }

        private async void OnLogoutTapped(object sender, TappedEventArgs e)
        {
            bool confirm = await DisplayAlert("Çýkýþ Yap", "Çýkýþ yapmak istediðine emin misin?", "Evet", "Vazgeç");

            if (!confirm)
                return;

            SessionService.Logout();
            Application.Current.MainPage = new LoginPage();
        }
    }
}