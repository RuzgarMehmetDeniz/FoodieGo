namespace FoodieGo.Models
{
    public class OrderDisplayItem
    {
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public decimal Total { get; set; }
        public int ItemCount { get; set; }
    }
}