namespace FoodieGo.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}
    private async void OnCategoriesTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CategoriesPage());
    }


}