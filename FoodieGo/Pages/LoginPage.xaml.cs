using FoodieGo.Services;

namespace FoodieGo.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly DatabaseService _db = new DatabaseService();

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginTapped(object sender, EventArgs e)
        {
            ErrorLabel.IsVisible = false;

            string email = EmailEntry.Text?.Trim();
            string password = PasswordEntry.Text?.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ShowError("E-posta ve þifreni gir.");
                return;
            }

            var user = await _db.LoginAsync(email, password);

            if (user == null)
            {
                ShowError("E-posta veya þifre hatalý.");
                return;
            }

            SessionService.Login(user);

            await Shell.Current.GoToAsync("//MainPage");
        }

        private async void OnGoToRegisterTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }

        private void ShowError(string message)
        {
            ErrorLabel.Text = message;
            ErrorLabel.IsVisible = true;
        }
    }
}