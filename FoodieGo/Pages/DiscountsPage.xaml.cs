using FoodieGo.Models;
using FoodieGo.Services;

namespace FoodieGo.Pages;

public partial class DiscountsPage : ContentPage
{
    private readonly DatabaseService _databaseService = new DatabaseService();

    public DiscountsPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Veritabanýndan indirimleri çek ve kapsayýcýya ver
        BannerContainer.BindingContext = await _databaseService.GetDiscountsAsync();
    }


}

