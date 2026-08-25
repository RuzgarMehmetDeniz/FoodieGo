using FoodieGo.Pages;

namespace FoodieGo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // TabBar'da olmayan, parametreyle/tıklayarak gidilen sayfalar
            Routing.RegisterRoute(nameof(ProductListPage), typeof(ProductListPage));
            Routing.RegisterRoute(nameof(DiscountsPage), typeof(DiscountsPage));
            Routing.RegisterRoute(nameof(SpinWheelPage), typeof(SpinWheelPage));
        }
    }
}
