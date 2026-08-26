using System.Collections.ObjectModel;

namespace FoodieGo.Pages
{
    // Geçici görüntüleme sýnýfý - DB baðlanýnca Models/Order kullanýlacak
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
                new() { OrderDate = "24 Aðu 2026", Status = "Teslim Edildi", Summary = "3 ürün", TotalPrice = 142.30m },
                new() { OrderDate = "18 Aðu 2026", Status = "Teslim Edildi", Summary = "5 ürün", TotalPrice = 268.90m },
                new() { OrderDate = "10 Aðu 2026", Status = "Ýptal Edildi", Summary = "2 ürün", TotalPrice = 61.40m },
            };
        }
    }
}