using FoodieGo.Pages;

namespace FoodieGo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Oturum "kapanınca sıfırlanır" mantığı gereği,
            // uygulama her açıldığında Login ekranından başlar.
            MainPage = new LoginPage();
        }
    }
}