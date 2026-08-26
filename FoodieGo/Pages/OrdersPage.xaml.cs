using System.Collections.ObjectModel;

namespace FoodieGo.Pages
{
    // Ge�ici g�r�nt�leme s�n�f� - DB ba�lan�nca Models/Order kullan�lacak
    public class OrderDisplayItem
    {
        public string OrderDate { get; set; }
        public string Status { get; set; }
        public string Summary { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public partial class OrdersPage : ContentPage
    {
        public OrdersPage()
        {
            InitializeComponent();

            OrdersList.ItemsSource = new ObservableCollection<OrderDisplayItem>
            {
                new() { OrderDate = "24 A�u 2026", Status = "Teslim Edildi", Summary = "3 �r�n", TotalPrice = 142.30m },
                new() { OrderDate = "18 A�u 2026", Status = "Teslim Edildi", Summary = "5 �r�n", TotalPrice = 268.90m },
                new() { OrderDate = "10 A�u 2026", Status = "�ptal Edildi", Summary = "2 �r�n", TotalPrice = 61.40m },
            };
        }

        private async void OnBackTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}