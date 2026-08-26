using FoodieGo.Services;

namespace FoodieGo.Pages
{
    public partial class RegisterPage : ContentPage
    {
        private readonly DatabaseService _db = new DatabaseService();

        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterTapped(object sender, EventArgs e)
        {
            ErrorLabel.IsVisible = false;

            string fullName = FullNameEntry.Text?.Trim();
            string email = EmailEntry.Text?.Trim();
            string password = PasswordEntry.Text?.Trim();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                ShowError("Lütfen tüm alanlarý doldur.");
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                ShowError("Geçerli bir e-posta adresi gir.");
                return;
            }

            if (password.Length < 6)
            {
                ShowError("Þifre en az 6 karakter olmalý.");
                return;
            }

            bool success = await _db.RegisterAsync(fullName, email, password);

            if (!success)
            {
                ShowError("Bu e-posta ile zaten bir hesap var.");
                return;
            }

            // Kayýt baþarýlý, kullanýcýyý oturuma al ve ana sayfaya yönlendir
            var user = await _db.LoginAsync(email, password);
            SessionService.Login(user);

            await Shell.Current.GoToAsync("//MainPage");
        }

        private async void OnGoToLoginTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        private void ShowError(string message)
        {
            ErrorLabel.Text = message;
            ErrorLabel.IsVisible = true;
        }
    }
}