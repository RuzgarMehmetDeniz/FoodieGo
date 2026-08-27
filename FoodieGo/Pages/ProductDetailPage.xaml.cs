using FoodieGo.Models;
using FoodieGo.Services;

namespace FoodieGo.Pages
{
    public partial class ProductDetailPage : ContentPage
    {
        private readonly DatabaseService _databaseService = new DatabaseService();
        private readonly Product _product;
        private int _quantity = 1;

        public ProductDetailPage(Product product)
        {
            InitializeComponent();
            _product = product;
            BindProduct();
        }

        private void BindProduct()
        {
            ProductNameLabel.Text = _product.Name;
            ProductUnitLabel.Text = string.IsNullOrWhiteSpace(_product.Unit)
                ? string.Empty
                : $"Birim: {_product.Unit}";
            ProductPriceLabel.Text = $"{_product.Price:0.00} TL";
            ProductImage.Source = _product.Image;
            QuantityLabel.Text = _quantity.ToString();
        }

        private async void OnBackTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnDecreaseTapped(object sender, EventArgs e)
        {
            if (_quantity <= 1)
                return;

            _quantity--;
            QuantityLabel.Text = _quantity.ToString();
        }

        private void OnIncreaseTapped(object sender, EventArgs e)
        {
            _quantity++;
            QuantityLabel.Text = _quantity.ToString();
        }

        private async void OnAddToCartClicked(object sender, EventArgs e)
        {
            try
            {
                await _databaseService.AddToCartAsync(_product.Id, _quantity);
                await DisplayAlert("Sepete Eklendi", $"{_product.Name} sepetine eklendi.", "Tamam");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", $"Ürün sepete eklenirken bir sorun oluþtu: {ex.Message}", "Tamam");
            }
        }
    }
}