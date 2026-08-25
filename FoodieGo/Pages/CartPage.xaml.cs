using FoodieGo.Services;

namespace FoodieGo.Pages;

public partial class CartPage : ContentPage
{
    private readonly DatabaseService _databaseService = new DatabaseService();
    public CartPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CartContainer.BindingContext = await _databaseService.GetCartDisplayItemsAsync();
    }

}